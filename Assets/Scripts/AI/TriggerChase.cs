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

    private void Awake()
    {
        aIChase = FindObjectOfType<AIChase>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement playerMovement))
        {
            //Player inside the trigger area
            if (!aIChase.Agent.isStopped)
            {
                //Copycat is chasing, there's no need to trigger the chase
                return;
            }
            float percentage = UnityEngine.Random.Range(0f, 1f);
            if (percentage < triggerPercentage)
            {
                //RNG said to start the chase
                Vector3 right = transform.TransformDirection(Vector3.right).normalized;
                float dotproduct = Vector3.Dot(right, playerMovement.CurrentMoveDirection);
                aIChase.AddMoreDestination(dotproduct > 0 ? copycatWaypointsRightTransform : copycatWaypointsLeftTransform, true);
                aIChase.Agent.Warp(dotproduct > 0 ? copyCatTransformRightDirection.position : copyCatTransformLeftDirection.position);
                aIChase.Agent.isStopped = true;
                aIChase.transform.GetChild(0).localPosition = Vector3.zero;
                aIChase.SetTimeToSwitchCamera(reactCopycatTime);
                //Rotate forward
                playerMovement.transform.rotation = Quaternion.LookRotation(playerWillLookAtCopycat ? aIChase.transform.position : playerMovement.transform.position - aIChase.transform.position);
                OnPlayerInsideTrigger?.Invoke(this, EventArgs.Empty);
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
