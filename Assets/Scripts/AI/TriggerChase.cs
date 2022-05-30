using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TriggerChase : MonoBehaviour
{
    public EventHandler OnPlayerInsideTrigger;
    [SerializeField] private Transform copyCatTransformRightDirection;
    [SerializeField] private Transform copyCatTransformLeftDirection;
    [SerializeField] private AIChase aIChase;
    [SerializeField] private BoxCollider getWaypointRightBoxcollider;
    [SerializeField] private BoxCollider getWaypointLeftBoxcollider;
    private Waypoint[] copycatWaypointsRightTransform; //Where the red arrow is pointing in the editor
    private Waypoint[] copycatWaypointsLeftTransform;
    [Range(0f,1f)]
    [SerializeField] private float triggerPercentage = 0.3f;
    [SerializeField] private bool playerWillLookAtCopycat = true;
    [SerializeField] private float reactCopycatTime = 5.0f;
    [SerializeField] private ChaseManager chaseManager;
    [SerializeField]private Transform targetLook;
    private void Awake()
    {
        targetLook = GameObject.Find("TargetLook").transform;
    }
    private void Start()
    {
        // Get the waypoints
        RaycastHit[] raycastHitRightArray = Physics.BoxCastAll(getWaypointRightBoxcollider.bounds.center, getWaypointRightBoxcollider.transform.localScale, getWaypointRightBoxcollider.transform.right, Quaternion.identity, getWaypointRightBoxcollider.size.x / 2);
        copycatWaypointsRightTransform = raycastHitRightArray.Where(t => t.transform.GetComponent<Waypoint>() != null).Select(t => t.transform.GetComponent<Waypoint>()).ToArray();
        copycatWaypointsRightTransform = copycatWaypointsRightTransform.OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).ToArray();
        RaycastHit[] raycastHitLefttArray = Physics.BoxCastAll(getWaypointLeftBoxcollider.bounds.center, getWaypointLeftBoxcollider.transform.localScale, getWaypointLeftBoxcollider.transform.right, Quaternion.identity, getWaypointLeftBoxcollider.size.x / 2);
        copycatWaypointsLeftTransform = raycastHitLefttArray.Where(t => t.transform.GetComponent<Waypoint>() != null).Select(t => t.transform.GetComponent<Waypoint>()).ToArray();
        copycatWaypointsLeftTransform = copycatWaypointsLeftTransform.OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).ToArray();
        // assign place enemies transform
        copyCatTransformRightDirection = playerWillLookAtCopycat ? raycastHitRightArray.Where(t => t.transform.tag == "PlaceEnemy").FirstOrDefault().transform 
            : raycastHitLefttArray.Where(t => t.transform.tag == "PlaceEnemy").FirstOrDefault().transform;
        copyCatTransformLeftDirection = playerWillLookAtCopycat ? raycastHitLefttArray.Where(t => t.transform.tag == "PlaceEnemy").FirstOrDefault().transform 
             : raycastHitRightArray.Where(t => t.transform.tag == "PlaceEnemy").FirstOrDefault().transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!aIChase.CheckIsCopycatIdle())
        {
            //Copycat is chasing, there's no need to trigger the chase
            return;
        }
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            //Player inside the trigger area           
            float percentage = UnityEngine.Random.Range(0f, 1f);
            if (percentage < triggerPercentage)
            {
                //RNG said to start the chase
                Vector3 right = transform.TransformDirection(Vector3.right).normalized;
                float dotproduct = Vector3.Dot(right, playerMovement.CurrentMoveDirection);
                aIChase.Agent.enabled = true;
                aIChase.AddMoreDestination(dotproduct > 0 ? copycatWaypointsRightTransform : copycatWaypointsLeftTransform);
                aIChase.Agent.Warp(dotproduct > 0 ? copyCatTransformRightDirection.position : copyCatTransformLeftDirection.position);
                aIChase.Agent.isStopped = true;
                aIChase.transform.GetChild(0).localPosition = Vector3.zero;
                chaseManager.SetTimeToSwitchCamera(reactCopycatTime);
                if (playerWillLookAtCopycat)
                {
                    targetLook.position = new Vector3(aIChase.transform.position.x, aIChase.transform.position.y, aIChase.transform.position.z);
                }
                else
                {
                    targetLook.position = 2 * transform.position - aIChase.transform.position;
                    Vector3 auxPosition = targetLook.transform.position;
                    auxPosition.y = Camera.main.transform.position.y;
                    targetLook.transform.position = auxPosition;
                }
                //Rotate forward
                playerMovement.transform.LookAt(targetLook);
                playerMovement.transform.rotation= Quaternion.Euler(new Vector3(0f, playerMovement.transform.rotation.eulerAngles.y, 0f));
                //Force player avoid "floating"
                OnPlayerInsideTrigger?.Invoke(this, EventArgs.Empty);
                this.gameObject.SetActive(false);
            }
        }
    }
}
