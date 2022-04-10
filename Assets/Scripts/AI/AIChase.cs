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
    private PlayerMovement playerMovement;
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
    private float currentTimeToChangeMove;
    [SerializeField]private float timeToChangeMoveSettings = 3.5f;
    //Boundry
    [SerializeField]private Vector2 idealDistance;
    [SerializeField] private float fovLerpDuration = 4f;
    private bool isfovLerpHappening;
    [SerializeField] private float speedLerpDuration = 4f;
    
    [SerializeField]private LayerMask seeTargetMask;
    public enum AgentState
    {
        Idle, Chase, Finished
    }
    private AgentState agentState;
    public AgentState State { get { return agentState; } set { agentState = value; } }
    private float lostPlayerTime = 0.0f;
    [SerializeField] private float dontseePlayerAmountTime = 3.0f;
    private List<Waypoint> waypointsListe;
    private ChaseManager chaseManager;
    private IEnumerator fovEnumerator, speedEnumerator, accelerationEnumerator;
    private bool isonMovementCourotine = false;
    private void Awake()
    {
        waypointsListe = new List<Waypoint>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true; // Make the agent stop
        chaseManager = FindObjectOfType<ChaseManager>();
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
                SetRubberBranding(); // Set Speed depending distance between copycat and Bryan
                MoveOrStopAgent();
                IsPlayerLookingAtCopyCat();
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
            StopCoroutine(fovEnumerator);
            fovEnumerator = FovLerp(vcam.m_Lens.FieldOfView, maxFOV);
        }
        else if(remainingDistance > idealDistance.y)
        {
            StopCoroutine(fovEnumerator);
            fovEnumerator = FovLerp(vcam.m_Lens.FieldOfView, minFOV);
        }
        else
        {
            StopCoroutine(fovEnumerator);
            fovEnumerator = FovLerp(vcam.m_Lens.FieldOfView, idealFOV);
        }
        StartCoroutine(fovEnumerator);
    }

    private void SetRubberBranding()
    {
        // rubber branding
        if (isonMovementCourotine)
        {
            return;
        }
        float remainingDistance = GetRemainingDistance();
        if(remainingDistance < idealDistance.x)
        {
            if (CheckIfSameValue(agent.speed, minSpeed))
                return;
            currentTimeToChangeMove = 0f;
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
            currentTimeToChangeMove = 0f;
            StopMovementCourotines();
            speedEnumerator = GetLerpMove(agent.speed, maxSpeed, true);
            accelerationEnumerator = GetLerpMove(agent.acceleration, maxAcceleration, false);
            StartMovementCourotines();
            ZoomInOutCamera();
            return;
        }
        currentTimeToChangeMove += Time.deltaTime;
        if(currentTimeToChangeMove >= timeToChangeMoveSettings)
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
        if(speedEnumerator == null || accelerationEnumerator == null)
        {
            return; //Avoid enumerator null errors
        }
        StopCoroutine(speedEnumerator);
        StopCoroutine(accelerationEnumerator);
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
        float distance = Vector3.Distance(agent.transform.position, playerMovement.transform.position);
        distance = Mathf.Clamp(distance, minClampDistance, maxClampDistance);
        return distance; // Distance between agent and Bryan (Player)
    }
    public void SetCurrentTimeToChangeMoveMax()
    {
        currentTimeToChangeMove = timeToChangeMoveSettings;
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
            lostPlayerTime = 0f;
            chaseManager.SwitchToFirstPerson();
        }
    }
    private bool IsCopycatSeeingPlayer()
    {
        if(Physics.Linecast(agent.transform.position, playerMovement.transform.position, seeTargetMask ))
        {
            //Copycat is not seing player (probably a door between them)
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
        float distance = Vector3.Distance(agent.transform.position, target.position);
        if(distance < 1.8f && waypointsListe.Count > 0)
        {
            SetWaypoint();
        }
        agent.SetDestination(target.position);
    }
    public void SetWaypoint()
    {
        Waypoint waypoint = waypointsListe[0];
        waypointsListe.RemoveAt(0);
        target = waypoint.transform;
        Vector3 auxTargetPosition = waypoint.transform.position;
        //A circle around
        auxTargetPosition.z = UnityEngine.Random.Range(waypoint.transform.position.z - 1, waypoint.transform.position.z + 1);
        auxTargetPosition.x = UnityEngine.Random.Range(waypoint.transform.position.x - 1, waypoint.transform.position.x + 1);
        target.position = auxTargetPosition;
    }
    public void AddMoreDestination(Waypoint[] waypointTransformArray)
    {
        waypointsListe.Clear();
        foreach (Waypoint waypoint in waypointTransformArray) // Add more destinations to where copycat can move
        {
            waypointsListe.Add(waypoint);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement player))
        {
            //Gameover
            chaseManager.SetEnableDisableSecondPersonRotatee(false);
            player.enabled = false;
            agentState = AgentState.Finished;
            agent.enabled = false;
        }
    }
}
