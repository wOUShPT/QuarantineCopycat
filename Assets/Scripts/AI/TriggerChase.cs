using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChase : MonoBehaviour
{
    public EventHandler OnPlayerInsideTrigger;
    [SerializeField] private Transform copyCatTransformLeftDirection;
    [SerializeField] private Transform copyCatTransformRightDirection;
    private AIChase aIChase;
    [SerializeField] private Waypoint[] copycatWaypointsLeftTransform;
    [SerializeField] private Waypoint[] copycatWaypointsRightTransform; //Where the red arrow is pointing in the editor
    [Range(0f,1f)]
    [SerializeField] private float triggerPercentage = 0.3f;
    [SerializeField] private bool playerWillLookAtCopycat = true;
    [SerializeField] private float reactCopycatTime = 5.0f;
    private ChaseManager chaseManager;
    [SerializeField]private Transform targetLook;
    private void Awake()
    {
        aIChase = FindObjectOfType<AIChase>();
        chaseManager = FindObjectOfType<ChaseManager>();
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
                //Force player avoid "floating"
                playerMovement.transform.rotation = Quaternion.Euler(playerMovement.transform.rotation.x, 0f, playerMovement.transform.rotation.z);
                OnPlayerInsideTrigger?.Invoke(this, EventArgs.Empty);
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
