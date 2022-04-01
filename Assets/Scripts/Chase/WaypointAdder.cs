using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAdder : MonoBehaviour
{
    private AIChase copycatScript;
    [SerializeField]private Waypoint[] waypointRightArray;
    [SerializeField] private Waypoint[] waypointLeftArray;
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
            Vector3 right = transform.TransformDirection(Vector3.right).normalized;
            float dotproduct = Vector3.Dot(right, playerMovement.CurrentMoveDirection);
            //Add the waypoints where player will pass while being chased
            copycatScript.AddMoreDestination( dotproduct >= 0 ? waypointRightArray : waypointLeftArray);
        }
    }
}
