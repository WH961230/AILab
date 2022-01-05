using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public float radius;
    public List<WayPoint> nearWayPoint;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        // Gizmos.DrawWireSphere(transform.position, radius);
    }
}
