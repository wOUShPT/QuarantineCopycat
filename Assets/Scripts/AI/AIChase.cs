using System;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using System.Collections;

public class AIChase : MonoBehaviour
{
    //Agent
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
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
    private enum AgentState
    {
        Idle, Chase, MeshLink 
    }
    private AgentState agentState;
    private void Awake()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
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
        yield return new WaitForSeconds(.1f);
        cameraManager.SwitchCamera(CameraManager.CinemachineStateSwitcher.SecondPerson);
        yield return new WaitForSeconds(5f);
        agent.isStopped = false; // Copycat starts moving
        StartCoroutine(StartIsOnMeshLink());
        playerRotate.enabled = true;
        agentState = AgentState.Chase;
        
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
        ZoomInOutCamera();
        SetRubberBranding();
    }
    private void ZoomInOutCamera()
    {
        if (CheckIsCopycatIdle())
            return;

        targetFOV = GetRemainingDistance() < idealDistance.x ? minFOV : targetFOV;
        targetFOV = GetRemainingDistance() > idealDistance.y ? maxFOV : targetFOV;
        vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, targetFOV, sensibility * Time.deltaTime);
    }

    private void SetRubberBranding()
    {
        if (CheckIsCopycatIdle())
            return;
        // rubber banding
        if(GetRemainingDistance() < idealDistance.x)
        {
            agent.speed = minSpeed;
            agent.acceleration = minAcceleration;
            return;
        }
        else if(GetRemainingDistance() > idealDistance.y)
        {
            agent.speed = maxSpeed;
            agent.acceleration = maxAcceleration;
            return;
        }
        //It's in the ideal distance
        agent.speed = normalSpeed;
        agent.acceleration =  normalAcceleration;
    }
    private bool CheckIsCopycatIdle()
    {
        return agentState == AgentState.Idle;
    }
    private float GetRemainingDistance()
    {
        float distance = 0f;
        Vector3[] corners = agent.path.corners;
        //NavMeshAgent.remainingDistance is still calculated only after the penultimate corner of the path has been reached,
        //and the agent is traversing the last segment.
        if(agent.pathPending || agent.pathStatus == NavMeshPathStatus.PathInvalid || corners.Length == 0)
        {
            //avoid get an infinite value
            distance = Mathf.Clamp(Mathf.RoundToInt(Vector3.Distance(transform.position, target.position)), minDistance, maxDistance);
            return distance;
        }
        if (corners.Length > 2)
        {
            //Measures all agent path corner points
            for (int i = 0; i < corners.Length - 1; i++)
            {
                distance += Mathf.RoundToInt(Vector3.Distance(corners[i], corners[i + 1]));
            }
            return Mathf.Clamp(distance, minDistance, maxDistance);
        }
        //In case  the remaining path is straight
        distance = Mathf.Clamp(Mathf.RoundToInt(agent.remainingDistance), minDistance, maxDistance);
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
        Vector3 direction = Vector3.Normalize(target.position - agent.transform.position);
        
        Vector3 newPosition;
        if (Mathf.Abs(Vector3.Dot(Vector3.right, direction)) > 0.9f && target.position.z != agent.transform.position.z)
        {
            //Move in forward
            newPosition = new Vector3(agent.transform.position.x, agent.transform.position.y, target.position.z);
            //agent.nextPosition = Vector3.Lerp(agent.transform.position, newPosition, agent.speed * Time.deltaTime);
            agent.nextPosition = newPosition;
        }
        else if (Mathf.Abs(Vector3.Dot(Vector3.forward, direction)) > 0.9f && target.position.x != agent.transform.position.x)
        {
            //Move vector 3 right and left
            newPosition = new Vector3(target.position.x, agent.transform.position.y, agent.transform.position.z);
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
        if(Physics.Linecast(agent.transform.position, target.position, seeTargetMask ))
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
        agent.SetDestination(target.position);
    }

    IEnumerator NormalSpeed()
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endPos = (data.endPos) + Vector3.up * agent.baseOffset;
        while (CheckDistance(endPos)) //until the navmesh reached the end position of the link
        {
            if (!IsPlayerLookingAtCopyCat())
            {
                agent.nextPosition = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);
            }
            yield return null;
        }
        agentState = AgentState.Chase;
    }
    private bool CheckDistance(Vector3 _endPos)
    {
        //This one for the straight
        Vector3 endPosDirection = Vector3.Normalize(_endPos - transform.position);
        if(Mathf.Abs(Vector3.Dot(Vector3.forward, endPosDirection)) >= 0.4f)
        {
            return Mathf.Abs(_endPos.z - agent.transform.position.z) > .3f;
        }
        if (Mathf.Abs(Vector3.Dot(Vector3.right, endPosDirection)) >= 0.4f)
        {
            return Mathf.Abs(_endPos.x - agent.transform.position.x) > .3f;
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
