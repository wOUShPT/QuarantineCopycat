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
    }
    private void Start()
    {        
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
                //Set target dynamically
                agent.SetDestination(target.position);
                break;
            case AgentState.MeshLink:
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

    IEnumerator NormalSpeed()
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endPos = (data.endPos) + Vector3.up * agent.baseOffset;
        while (agent.transform.position != endPos) //until the navmesh reached the end position of the link
        {
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);
            yield return null;
        }
        agentState = AgentState.Chase;

    }
}
