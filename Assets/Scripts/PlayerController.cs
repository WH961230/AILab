using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerController : MonoBehaviour
{
    public PlayerController targetPlayer;
    public WayPointManager manager;
    public float speed;
    public float moveSpeed;
    public bool isAi;
    public WayPoint NearWayPoint;
    public float nearWayPointDistance;
    public float checkReachDis;
    void Start()
    {
        manager = FindObjectOfType<WayPointManager>();
    }

    void Update()
    {
        PlayerEvent();
        AIEvent();
    }

    void PlayerEvent()
    {
        if (isAi)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }

    void AIEvent()
    {
        if (!isAi)
        {
            return;
        }

        if (NearWayPoint != null)
        {
            if (HasReachWayPoint(NearWayPoint, checkReachDis))
            {
                NearWayPoint = null;
            }
        }

        if (NearWayPoint == null)
        {
            NearWayPoint = manager.GetNearWayPoint(nearWayPointDistance, transform.position, manager.wayPoints);
        }

        //向点位移
        transform.position = Vector3.Lerp(transform.position, NearWayPoint.transform.position, Time.deltaTime * moveSpeed);
    }

    bool HasReachWayPoint(WayPoint target, float checkReachDis)
    {
        var dis = Vector3.Distance(target.transform.position, transform.position);
        if (dis < checkReachDis)
        {
            return true;
        }

        return false;
    }
}
