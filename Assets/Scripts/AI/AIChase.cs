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
    private CinemachineFPExtension fPExtension;
    [SerializeField]private CinemachineVirtualCamera vcam;
    [SerializeField] private float minDistance = 2f;
    [SerializeField] private float maxDistance = 6f;
    [SerializeField] private float minFOV = 20f;
    [SerializeField] private float maxFOV = 60f;
    private float targetFOV;
    [SerializeField] private float sensibility = 0.2f;
    private CameraManager cameraManager;
    private TriggerChase triggerChase;
    [SerializeField] private LayerMask chaseMask;
    //Where is copycat grounded
    [SerializeField] private LayerMask corridorMask;
    private Transform lastCorridorGrounded;
    private PlayerSPRotate playerRotate;
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
        fPExtension = FindObjectOfType<CinemachineFPExtension>();
        cameraManager = FindObjectOfType<CameraManager>();
        triggerChase = FindObjectOfType<TriggerChase>();
        playerRotate = FindObjectOfType<PlayerSPRotate>();
    }
    private void Start()
    {
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
    }
    private void ZoomInOutCamera()
    {
        if (fPExtension.IsFirstPerson) // it's not in the second perspective
        {
            return;
        }
        float distance = Mathf.RoundToInt(Vector3.Distance(transform.position, target.position));
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        switch (distance)
        {
            case 2:
                targetFOV = maxFOV;
                break;
            case 3:
                targetFOV = maxFOV - 10;
                break;
            case 4:
                targetFOV = maxFOV - 20;
                break;
            case 5:
                targetFOV = minFOV + 10; // 30
                break;
            case 6:
            default:
                targetFOV = minFOV; // 20
                break;
        }
        vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, targetFOV, sensibility * Time.deltaTime);
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
        //Seeing direction
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 direction = Vector3.Normalize(target.position - transform.position);
        
        if(!IsPlayerLookingAtCopyCat())
        {
            //Player is looking on front
            return;
        }
        float dot = Vector3.Dot(forward, direction);
        if (dot > 0)
        {
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
    }

    private bool IsPlayerLookingAtCopyCat()
    {
        if (Vector3.Dot(transform.TransformDirection(Vector3.forward), playerRotate.LookDirection) >= 0)
        {
            //Player is looking on front or perpendicular
            return false;
        }
        //Player is looking at copycat
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
