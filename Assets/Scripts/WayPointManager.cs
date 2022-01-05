using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public List<WayPoint> wayPoints;
    public List<WayPoint> retWayPoints;
    public float showLineRange;
    void Start()
    {
        
    }

    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < wayPoints.Count; i++)
        {
            var wayPoint = wayPoints[i];
            var wayPos = wayPoint.transform.position;
            for (int j = 0; j < wayPoints.Count; j++)
            {
                var currentWP = wayPoints[j];
                var curPos = currentWP.transform.position;
                var isBlock = Physics.Raycast(wayPos, curPos - wayPos, showLineRange, 1 << LayerMask.NameToLayer("Building"));
                if (isBlock)
                {
                    continue;
                }
                var distance = Vector3.Distance(wayPoint.transform.position, currentWP.transform.position);
                if (distance < showLineRange)
                {
                    Gizmos.DrawLine(wayPoint.transform.position, currentWP.transform.position);
                    Gizmos.color = Color.red;
                }
            }
        }
    }
    
    public WayPoint GetNearWayPoint(float maxRange, Vector3 target, List<WayPoint> wayPoints)
    {
        WayPoint wp = null;
        float distance = maxRange;
        for (int i = 0; i < wayPoints.Count; i++)
        {
            var curDis = Vector3.Distance(target, wayPoints[i].transform.position);
            if (curDis < distance)
            {
                distance = curDis;
                wp = wayPoints[i];
            }
        }
        return wp;
    }

    public List<WayPoint> SetRetWayPoints(WayPoint start, WayPoint end, List<WayPoint> tempList)
    {
        float distance = 99999;
        WayPoint retWayPoint = null;
        for (int i = 0; i < tempList.Count; i++)
        {
            var wayPoint = tempList[i];
            if (start == wayPoint)
            {
                continue;
            }

            var curDis = Vector3.Distance(wayPoint.transform.position, start.transform.position);
            if (curDis < distance)
            {
                distance = curDis;
                retWayPoint = wayPoint;
            }
        }

        if (retWayPoint == end)
        {
            
        }
        else
        {
            
        }

        return null;
    }
}
