using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WaypointAdder : MonoBehaviour
{
    private AIChase copycatScript;
    [SerializeField] private BoxCollider rightGetAdder;
    [SerializeField] private BoxCollider leftGetAdder;
    private Waypoint[] waypointRightArray;
    private Waypoint[] waypointLeftArray;
    private bool canAddWaypoints = true;
    private float currentTimeToWaypoints = 0.0f;
    [SerializeField] private float timeToAddWaypointsAgain = 8f;
    private delegate void TimeAction();
    private TimeAction timeAction;
    private void Awake()
    {
        copycatScript = FindObjectOfType<AIChase>();
    }
    private void Start()
    {
        // Left and right based on waypoint adder transfor position
        RaycastHit[] raycastHitRightArray = Physics.BoxCastAll(rightGetAdder.bounds.center, rightGetAdder.bounds.extents /2, rightGetAdder.transform.right, rightGetAdder.transform.rotation, rightGetAdder.size.z);
        waypointRightArray = raycastHitRightArray.Where(t => t.transform.GetComponent<Waypoint>() != null).Select(t => t.transform.GetComponent<Waypoint>()).ToArray();
        waypointRightArray = waypointRightArray.OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).ToArray();
        RaycastHit[] raycastHitLefttArray = Physics.BoxCastAll(leftGetAdder.bounds.center, leftGetAdder.bounds.extents / 2, -leftGetAdder.transform.right, leftGetAdder.transform.rotation, leftGetAdder.size.z);
        waypointLeftArray = raycastHitLefttArray.Where(t => t.transform.GetComponent<Waypoint>() != null).Select(t => t.transform.GetComponent<Waypoint>()).ToArray();
        waypointLeftArray = waypointLeftArray.OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).ToArray();
    }
    private void Update()
    {
        timeAction?.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!canAddWaypoints)
        {
            return;
        }
        if (!copycatScript.Agent.enabled)
        {
            return;
        }
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
            canAddWaypoints = false;
            timeAction += WaitToAddWaypoints;
        }
    }
    private void WaitToAddWaypoints()
    {
        currentTimeToWaypoints += Time.deltaTime;
        if(currentTimeToWaypoints >= timeToAddWaypointsAgain)
        {
            currentTimeToWaypoints = 0;
            canAddWaypoints = true;
            timeAction -= WaitToAddWaypoints;
        }
    }
}
