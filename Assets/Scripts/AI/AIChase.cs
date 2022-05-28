using System;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;

public class AIChase : MonoBehaviour
{
    //Agent
    private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] private Transform target;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField] private PlayerSPRotate playerRotate;
    //Zoom lens
    [SerializeField]private CinemachineVirtualCamera vcam;
    [SerializeField] private float minClampDistance = 2f;
    [SerializeField] private float maxClampDistance = 6f;
    [SerializeField] private float minFOV = 20f;
    [SerializeField] private float maxFOV = 60f;
    [SerializeField] private float idealFOV = 40f;
    //Rubber banding
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float minAcceleration = 2f;
    [SerializeField] private float maxAcceleration = 4f;
    private float normalSpeed, normalAcceleration;
    private float currentTimeChangeMove;
    [SerializeField]private float timeChangeMoveSettings = 3.5f;
    //Boundry
    [SerializeField]private Vector2 idealDistance;
    [SerializeField] private float fovLerpDuration = 4f;
    private bool isfovLerpHappening;
    [SerializeField] private float speedLerpDuration = 4f;
    
    [SerializeField]private LayerMask seeTargetMask;
    [SerializeField] private LayerMask playerMask;
    public enum AgentState
    {
        Idle, Chase, Finished
    }
    private AgentState agentState;
    public AgentState State { get { return agentState; } set { agentState = value; } }
    private float lostPlayerTime = 0.0f;
    [SerializeField] private float dontseePlayerAmountTime = 3.0f;
    private List<Waypoint> waypointsList;
    [SerializeField]private ChaseManager chaseManager;
    private IEnumerator fovEnumerator, speedEnumerator, accelerationEnumerator;
    private bool isonMovementCourotine = false;
    [SerializeField] private Transform cameraPivot;
    private Vector3 _startHeadPosition;
    private Vector3 _currentHeadPosition;
    [Range(0f, 3f)] [SerializeField] private float headPositionMultiplier = 0.3f;
    [SerializeField, Range(0, 1.5f)]
    private float headBobIntensity;
    [SerializeField]
    private float headBobSpeed;
    [SerializeField] private float closeDistance = 5.0f;
    private bool canBeTriggerByDot = true;
    private void Awake()
    {
        waypointsList = new List<Waypoint>();
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true; // Make the agent stop
        _currentHeadPosition = cameraPivot.localPosition;
        _startHeadPosition = _currentHeadPosition;
    }
    private void Start()
    {
        normalSpeed = agent.speed;
        normalAcceleration = agent.acceleration;
    }
    private void Update()
    {
        if (!agent.enabled || agent.isStopped)
        {
            return; // The agent is stopped or is not enabled
        }
        switch (agentState)
        {
            case AgentState.Idle:
            case AgentState.Finished:
                break;
            case AgentState.Chase:
                //Set target dynamically
                SetRubberBanding(); // Set Speed depending distance between copycat and Bryan
                MoveOrStopAgent();
                IsPlayerLookingAtCopyCat();
                UpdateHeadPosition();
                //IsCopycatLookingPlayerFace();
                break;
        }
    }
    private void ZoomInOutCamera()
    {
        if (isfovLerpHappening)
        {
            return;
        }
        //Zoom depends on between copycat and player's distance
        float remainingDistance = GetRemainingDistance();
        isfovLerpHappening = true;
        if (remainingDistance < idealDistance.x)
        {
            StopfovCourotine();
            fovEnumerator = FovLerp(vcam.m_Lens.FieldOfView, maxFOV);
        }
        else if(remainingDistance > idealDistance.y)
        {
            StopfovCourotine();
            fovEnumerator = FovLerp(vcam.m_Lens.FieldOfView, minFOV);
        }
        else
        {
            StopfovCourotine();
            fovEnumerator = FovLerp(vcam.m_Lens.FieldOfView, idealFOV);
        }
        StartCoroutine(fovEnumerator);
    }
    private void StopfovCourotine()
    {
        if(fovEnumerator != null)
        {
            StopCoroutine(fovEnumerator);
        }
    }

    private void SetRubberBanding()
    {
        // rubber banding
        if (isonMovementCourotine)
        {
            return;
        }
        float remainingDistance = GetRemainingDistance();
        if(remainingDistance < idealDistance.x)
        {
            if (CheckIfSameValue(agent.speed, minSpeed))
                return;
            currentTimeChangeMove = 0f;
            StopMovementCourotines();
            speedEnumerator = GetLerpMove(agent.speed, minSpeed, true);
            accelerationEnumerator = GetLerpMove(agent.acceleration, minAcceleration, false);
            StartMovementCourotines();
            ZoomInOutCamera();
            return;
        }
        if(remainingDistance > idealDistance.y)
        {
            if (CheckIfSameValue(agent.speed, maxSpeed))
                return;
            currentTimeChangeMove = 0f;
            StopMovementCourotines();
            speedEnumerator = GetLerpMove(agent.speed, maxSpeed, true);
            accelerationEnumerator = GetLerpMove(agent.acceleration, maxAcceleration, false);
            StartMovementCourotines();
            ZoomInOutCamera();
            return;
        }
        currentTimeChangeMove += Time.deltaTime;
        if(currentTimeChangeMove >= timeChangeMoveSettings)
        {
            if (CheckIfSameValue(agent.speed, normalSpeed))
                return;
            StopMovementCourotines();
            //It's in the ideal distance
            speedEnumerator = GetLerpMove(agent.speed, normalSpeed, true);
            accelerationEnumerator = GetLerpMove(agent.acceleration, normalAcceleration, false);
            StartMovementCourotines();
            ZoomInOutCamera();
        }
    }
    private bool CheckIfSameValue(float avalue, float bvalue)
    {
        return avalue == bvalue;
    }
    private void StopMovementCourotines()
    {
        if(accelerationEnumerator != null)
        {
            StopCoroutine(speedEnumerator);
        }
        if(accelerationEnumerator != null)
        {
            StopCoroutine(accelerationEnumerator);
        }
        
    }
    private void StartMovementCourotines()
    {
        //Start move related courotines
        StartCoroutine(speedEnumerator);
        StartCoroutine(accelerationEnumerator);
    }
    private IEnumerator GetLerpMove(float startvalue, float targetvalue, bool isSpeed)
    {
        //Need to make a way to prevent being called multiple times
        isonMovementCourotine = true;
        float timeElapsed = 0f;
        while (timeElapsed < speedLerpDuration)
        {
            if (isSpeed)
            {
                agent.speed = Mathf.Lerp(startvalue, targetvalue, timeElapsed / speedLerpDuration);
            }
            else
            {
                agent.acceleration = Mathf.Lerp(startvalue, targetvalue, timeElapsed / speedLerpDuration);
            }
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        if (isSpeed)
        {
            agent.speed = targetvalue;
        }
        else
        {
            agent.acceleration = targetvalue;
        }
        isonMovementCourotine = false;
    }
    private IEnumerator FovLerp(float startvalue, float endValue)
    {
        isfovLerpHappening = true;
        float fovTimeElapsed = 0f;
        while (fovTimeElapsed < fovLerpDuration)
        {
            vcam.m_Lens.FieldOfView = Mathf.Lerp(startvalue, endValue, fovTimeElapsed / fovLerpDuration);
            fovTimeElapsed += Time.deltaTime;
            yield return null;
        }
        vcam.m_Lens.FieldOfView = endValue;
        isfovLerpHappening = false;
    }
    public bool CheckIsCopycatIdle()
    {
        return agentState == AgentState.Idle;
    }
    private float GetRemainingDistance()
    {
        //See distance between agent and player
        float distance = Vector3.Distance(agent.transform.position, playerMovement.transform.position);
        distance = Mathf.Clamp(distance, minClampDistance, maxClampDistance);
        return distance; // Distance between agent and Bryan (Player)
    }
    public void SetCurrentTimeToChangeMoveMax()
    {
        currentTimeChangeMove = timeChangeMoveSettings;
    }
    private void IsPlayerLookingAtCopyCat()
    {
        if (!IsCopycatSeeingPlayer())
        {
            CheckLostPlayerTime();
            return;
        }
        lostPlayerTime = 0.0f;
    }
    private void CheckLostPlayerTime()
    {
        lostPlayerTime += Time.deltaTime;
        if( lostPlayerTime >= dontseePlayerAmountTime)
        {
            //Switch to bryan's perspective
            PrepareSwitchCamera();
        }
    }
    private void PrepareSwitchCamera()
    {
        //Switch to bryan's perspective
        lostPlayerTime = 0f;
        chaseManager.SwitchToFirstPerson();
    }
    private bool IsCopycatSeeingPlayer()
    {
        Vector3 playerSeeOffsetUp = new Vector3(playerMovement.transform.position.x, playerMovement.transform.position.y + 1f, playerMovement.transform.position.z);
        Vector3 playerSeeOffsetLeft = new Vector3(playerMovement.transform.position.x, playerMovement.transform.position.y + 1f, playerMovement.transform.position.z - 0.3f);
        Vector3 playerSeeOffsetRight = new Vector3(playerMovement.transform.position.x, playerMovement.transform.position.y + 0.5f, playerMovement.transform.position.z + 0.3f);

        Debug.DrawLine(agent.transform.position, playerSeeOffsetUp, Color.red);
        Debug.DrawLine(agent.transform.position, playerSeeOffsetLeft, Color.red);
        Debug.DrawLine(agent.transform.position, playerSeeOffsetRight, Color.red);
        bool IsBlockingVisionUp = Physics.Linecast(agent.transform.position, playerSeeOffsetUp, seeTargetMask);
        bool IsBlockingVisionLeft = Physics.Linecast(agent.transform.position, playerSeeOffsetLeft, seeTargetMask);
        bool IsBlockingVisionRight = Physics.Linecast(agent.transform.position, playerSeeOffsetRight, seeTargetMask);
        if (IsBlockingVisionUp && IsBlockingVisionLeft && IsBlockingVisionRight)
        {
            //Copycat is not seing player (probably a door between them)
            Debug.DrawLine(agent.transform.position, playerSeeOffsetUp, Color.green);
            Debug.DrawLine(agent.transform.position, playerSeeOffsetLeft, Color.green);
            Debug.DrawLine(agent.transform.position, playerSeeOffsetRight, Color.green);
            return false;
        }
        return true;
    }

    private void MoveOrStopAgent()
    {
        //Start running
        CheckNeedToChangeWaypoint();
    }
    private void CheckNeedToChangeWaypoint()
    {
        Vector3 auxtargetDistance = new Vector3(target.position.x, agent.transform.position.y, target.position.z);
        float distance = Vector3.Distance(agent.transform.position, auxtargetDistance);
        if (distance < 1f && waypointsList.Count > 0)
        {
            // Go to next waypoint
            SetWaypoint();
            agent.ResetPath();
            
        }
        agent.SetDestination(IsCopycatSeeingPlayer() ? playerMovement.transform.position : target.position);
    }
    public void SetWaypoint()
    {
        if(waypointsList.Count == 0)
        {
            return;
        }
        Waypoint waypoint = waypointsList[0];
        waypointsList.RemoveAt(0);
        target = waypoint.transform;
        Vector3 auxTargetPosition = waypoint.transform.position;
        //A circle around
        auxTargetPosition.z = UnityEngine.Random.Range(waypoint.transform.position.z - 1, waypoint.transform.position.z + 1);
        auxTargetPosition.x = UnityEngine.Random.Range(waypoint.transform.position.x - 1, waypoint.transform.position.x + 1);
        target.position = auxTargetPosition;
    }
    public void AddMoreDestination(Waypoint[] waypointTransformArray)
    {
        waypointsList.Clear();
        foreach (Waypoint waypoint in waypointTransformArray) // Add more destinations to where copycat can move
        {
            waypointsList.Add(waypoint);
        }
        SetWaypoint();
        agent.SetDestination(target.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!agent.enabled || agentState == AgentState.Idle)
        {
            return;
        }
        if(other.TryGetComponent(out PlayerMovement player))
        {
            if(agentState == AgentState.Finished)
            {
                return;
            }
            //Gameover
            Debug.Log("Gameover by trigger");
            PrepareGameover(player);
        }
    }
    private void PrepareGameover(PlayerMovement player)
    {
        agentState = AgentState.Finished;
        agent.velocity = Vector3.zero;
        agent.ResetPath();
        chaseManager.SetEnableDisableSecondPersonRotatee(false);
        player.enabled = false;        
        
        StopAllCoroutines();
        StartCoroutine(TurnComponentsByCaught());
    }
    private IEnumerator TurnComponentsByCaught()
    {
        //Disabling or enabling components after copycat got player (Bryan) Gameover
        yield return new WaitForSeconds(3f);
        agent.ResetPath();
        agent.isStopped = true; //Copycat stops moving
        agent.velocity = Vector3.zero;
        agent.speed = 0f;
        agent.acceleration = 0f;
        agent.enabled = false;
        //Animator maybe
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        // Visual feedback
        yield return new WaitForSeconds(2f);
        chaseManager.EnableGameOverScreen();
    }
    void UpdateHeadPosition()
    {
        if (agent.velocity.x != 0 || agent.velocity.z != 0)
        {
            _currentHeadPosition.y = _startHeadPosition.y - Mathf.PingPong(Time.time * headBobSpeed * (headBobIntensity * headPositionMultiplier), headBobIntensity * 0.1f);
        }
        else
        {
            _currentHeadPosition.y = Mathf.Lerp(cameraPivot.transform.localPosition.y, _startHeadPosition.y, Time.deltaTime * 20f);
        }
        cameraPivot.transform.localPosition = _currentHeadPosition;
    }
    //Prevent Copycat seeing bryan's face
    private bool IsCopycatLookingPlayerFace()
    {
        if (agentState == AgentState.Finished)
        {
            return false;
        }
        float angle = Vector3.Angle(playerRotate.transform.forward, playerRotate.transform.position - vcam.transform.position);
        // square the distance we compare with
        if (!canBeTriggerByDot)
        {
            if(angle < 80f)
            {
                canBeTriggerByDot = true;
            }
            return false;
        }
        if (angle > 80f && IsCopycatSeeingPlayer())
        {
            Debug.Log("Gameover by dot");
            return true;
        }
        return false;
    }
    public void SetCanBeTriggerByDot(bool condition)
    {
        canBeTriggerByDot = condition;
    }
}
