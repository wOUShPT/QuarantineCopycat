using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAdder : MonoBehaviour
{
    private AIChase copycatScript;
    private Waypoint[] waypointArray;
    private void Awake()
    {
        copycatScript = FindObjectOfType<AIChase>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (copycatScript.Agent.isStopped)
        {
            return;
        }
        if(other.TryGetComponent(out PlayerMovement playerMovement))
        {
            //Add the waypoints where player will pass while being chased
            copycatScript.AddMoreDestination(waypointArray, true);
        }
    }
}
