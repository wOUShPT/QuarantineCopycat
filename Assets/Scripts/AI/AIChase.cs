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
    [SerializeField] private Transform target;
    private PlayerMovement playerMovement;
    //Zoom lens
    [SerializeField]private CinemachineVirtualCamera vcam;
    [SerializeField] private float minDistance = 2f;
    [SerializeField] private float maxDistance = 6f;
    [SerializeField] private float minFOV = 20f;
    [SerializeField] private float maxFOV = 60f;
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float minAcceleration = 2f;
    [SerializeField] private float maxAcceleration = 4f;
    private float normalSpeed, normalAcceleration;
    //Boundry
    [SerializeField]private Vector2 idealDistance;
    private float targetFOV;
    [SerializeField] private float sensibility = 0.2f;
    private CameraManager cameraManager;
    private TriggerChase triggerChase;
    [SerializeField] private LayerMask chaseMask;
    //Where is copycat grounded
    [SerializeField] private LayerMask corridorMask;
    private Transform lastCorridorGrounded;
    private PlayerSPRotate playerRotate;
    [SerializeField]private LayerMask seeTargetMask;
    [SerializeField] private CameraFunctions playerCameraFunctions;
    private enum AgentState
    {
        Idle, Chase, MeshLink, Finished
    }
    private AgentState agentState;

    private float changeSpeedSmooth = 0.1f;

    private Queue<Waypoint> waypointsQueue;
    private void Awake()
    {
        waypointsQueue = new Queue<Waypoint>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true; // Make the agent stop
        cameraManager = FindObjectOfType<CameraManager>();
        triggerChase = FindObjectOfType<TriggerChase>();
        playerRotate = FindObjectOfType<PlayerSPRotate>();
    }
    private void Start()
    {
        normalSpeed = agent.speed;
        normalAcceleration = agent.acceleration;
        playerRotate.enabled = false;
        triggerChase.OnPlayerInsideTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }
    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (agent.isStopped) //Switch the camera
        {
            SwitchToSecondCamera();
            triggerChase.OnPlayerInsideTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }
    }
    private void SwitchToSecondCamera()
    {
        StartCoroutine(SetupChase());
    }
    IEnumerator SetupChase()
    {
        Camera.main.cullingMask = chaseMask;
        PlayerProperties.FreezeAim = true;
        PlayerProperties.FreezeInteraction = true;
        PlayerProperties.FreezeMovement = true;
        Debug.Log("Chaseee!");
        playerCameraFunctions.ResetCameraTransform();
        yield return new WaitForSeconds(.1f);
        cameraManager.SwitchCamera(CameraManager.CinemachineStateSwitcher.SecondPerson);
        UIManager.Instance.ToggleReticle(false);
        yield return new WaitForSeconds(5f);
        agent.isStopped = false; // Copycat starts moving
        StartCoroutine(StartIsOnMeshLink());
        playerRotate.enabled = true;
        agentState = AgentState.Chase;
        PlayerProperties.FreezeMovement = false;
        SetWaypoint();

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
                MimicPlayerMovements();
                //Set target dynamically
                MoveOrStopAgent();
                break;
            case AgentState.MeshLink:
                MimicPlayerMovements();
                break;
        }
        
    }
    void LateUpdate()
    {
        //ZoomInOutCamera();
        SetRubberBranding();
    }
    private void ZoomInOutCamera()
    {
        if (CheckIsCopycatIdle())
            return;
        targetFOV = GetRemainingDistance() < ((idealDistance.x + idealDistance.y) / 2) ? minFOV : targetFOV;
        vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, targetFOV, sensibility);
    }

    private void SetRubberBranding()
    {
        if (CheckIsCopycatIdle())
            return;
        // rubber banding
        float remainingDistance = GetRemainingDistance();
        if(remainingDistance < idealDistance.x)
        {
            agent.speed = GetLerpSpeed(agent.speed, minSpeed);
            agent.acceleration = GetLerpSpeed(agent.acceleration, minAcceleration);
            return;
        }
        else if(remainingDistance > idealDistance.y)
        {
            agent.speed = GetLerpSpeed(agent.speed, maxSpeed);
            agent.acceleration = GetLerpSpeed(agent.acceleration, maxAcceleration);
            return;
        }
        //It's in the ideal distance
        agent.speed = GetLerpSpeed(agent.speed, normalSpeed);
        agent.acceleration =  GetLerpSpeed(agent.acceleration, normalAcceleration);
    }
    private float GetLerpSpeed(float currentSpeed, float tartgetSpeed)
    {
        return Mathf.Lerp(currentSpeed, tartgetSpeed, changeSpeedSmooth);
    }
    private bool CheckIsCopycatIdle()
    {
        return agentState == AgentState.Idle;
    }
    private float GetRemainingDistance()
    {
        float distance = Vector3.Distance(agent.transform.position, playerMovement.transform.position);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        return distance;
    }
    private IEnumerator StartIsOnMeshLink()
    {
        //Courotine for the navmesh link
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                //Custom traverse link
                agentState = AgentState.MeshLink;
                yield return StartCoroutine(NormalSpeed()); //with normal speed
                agent.CompleteOffMeshLink();
                yield return null;
                agentState = AgentState.Chase;
                agent.SetDestination(target.position);
            }
            yield return null;
        }
    }
    private void MimicPlayerMovements()
    {
        if (!IsPlayerLookingAtCopyCat())
        {
            //Player is looking on front
            return;
        }
        //Seeing direction
        Transform playerTransform = playerMovement.transform;
        Vector3 direction = Vector3.Normalize(playerTransform.position - agent.transform.position);
        
        Vector3 newPosition;
        if (Mathf.Abs(Vector3.Dot(Vector3.right, direction)) > 0.9f && playerTransform.position.z != agent.transform.position.z)
        {
            //Move in forward
            newPosition = new Vector3(agent.transform.position.x, agent.transform.position.y, playerTransform.position.z);
            agent.nextPosition = newPosition;
        }
        else if (Mathf.Abs(Vector3.Dot(Vector3.forward, direction)) > 0.9f && playerTransform.position.x != agent.transform.position.x)
        {
            //Move vector 3 right and left
            newPosition = new Vector3(playerTransform.position.x, agent.transform.position.y, agent.transform.position.z);
            agent.nextPosition = newPosition;
        }
    }

    private bool IsPlayerLookingAtCopyCat()
    {
        if (!IsCopycatSeeingPlayer())
        {
            return false;
        }
        Vector3 forward = vcam.transform.TransformDirection(Vector3.forward).normalized;
        if (Vector3.Dot(forward, playerRotate.LookDirection.normalized) >= 0.2f)
        {
            //Player is looking on front or perpendicular
            return false;
        }
        //Player is looking at copycat
        return true;
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
        if (IsPlayerLookingAtCopyCat())
        {
            agent.isStopped = true;
            agent.ResetPath();
            return;
        }
        //Start running
        agent.isStopped = false;
        CheckNeedToChangeWaypoint();
    }

    private void CheckNeedToChangeWaypoint()
    {
        float distance = Vector3.Distance(agent.transform.position, target.position);
        if(distance < 1.8f && waypointsQueue.Count > 0)
        {
            SetWaypoint();
        }
        agent.SetDestination(target.position);
        
    }
    private void SetWaypoint()
    {
        Waypoint waypoint = waypointsQueue.Dequeue();
        target = waypoint.transform;
        Vector3 auxTargetPosition = waypoint.transform.position;
        if (waypoint.IsRandomizedOnCircle())
        {
            //A circle around
            auxTargetPosition.z = UnityEngine.Random.Range(waypoint.transform.position.z - 1, waypoint.transform.position.z + 1);
            auxTargetPosition.x = UnityEngine.Random.Range(waypoint.transform.position.x - 1, waypoint.transform.position.x + 1);
        }
        else
        {
            Vector3 mindVector = (-1.0f) * waypoint.transform.TransformDirection(waypoint.transform.forward);
            Vector3 maxVector = 1.0f * waypoint.transform.TransformDirection(waypoint.transform.forward);
            auxTargetPosition += new Vector3(UnityEngine.Random.Range(mindVector.x, maxVector.x), 0, UnityEngine.Random.Range(mindVector.z, maxVector.z));
        }
        target.position = auxTargetPosition;
    }
    IEnumerator NormalSpeed()
    {
        //Travel at normal speed on the links
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endPos = (data.endPos) + Vector3.up * agent.baseOffset;
        endPos.y = agent.transform.position.y;
        while (CheckDistance(endPos)) //until the navmesh reached the end position of the link
        {
            if (!IsPlayerLookingAtCopyCat())
            {
                agent.nextPosition = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);
            }
            yield return null;
        }
    }
    public void AddMoreDestination(Waypoint [] waypointTransformArray)
    {
        foreach (Waypoint waypoint in waypointTransformArray) // Add more destinations to where copycat can move
        {
            waypointsQueue.Enqueue(waypoint);
        }
    }
    private bool CheckDistance(Vector3 _endPos)
    {
        //This one for the straight
        Vector3 endPosDirection = Vector3.Normalize(_endPos);
        Debug.Log(endPosDirection);
        if(Mathf.Abs(Vector3.Dot(Vector3.forward, endPosDirection)) >= 0.4f)
        {
            //Forward Direction globally
            return Mathf.Abs(_endPos.z - agent.transform.position.z) > .1f;
        }
        if (Mathf.Abs(Vector3.Dot(Vector3.right, endPosDirection)) >= 0.4f)
        {
            //Right Direction globally
            return Mathf.Abs(_endPos.x - agent.transform.position.x) > .1f;
        }
        return true;
    }
    public Transform CheckDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 300, corridorMask))
        {
            if(hit.transform.parent.TryGetComponent(out CorridorInfo corridorInfo))
            {
                lastCorridorGrounded = corridorInfo.transform;
                return lastCorridorGrounded;
            }
            if (hit.transform.parent.parent.TryGetComponent(out CorridorInfo parentparentCorridorInfo))
            {
                lastCorridorGrounded = parentparentCorridorInfo.transform;
                return lastCorridorGrounded;
            }
        }
        return lastCorridorGrounded;
    }
}
