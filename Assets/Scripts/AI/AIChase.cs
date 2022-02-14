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
    private void Awake()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true; // Make the agent stop
        fPExtension = FindObjectOfType<CinemachineFPExtension>();
        cameraManager = FindObjectOfType<CameraManager>();
    }
    private void Start()
    {
        SwitchToSecondCamera();
    }
    private void SwitchToSecondCamera()
    {
        StartCoroutine(SetupChase());
    }
    IEnumerator SetupChase()
    {
        yield return new WaitForSeconds(3f);
        cameraManager.SwitchCamera(CameraManager.CinemachineStateSwitcher.SecondPerson);
        yield return new WaitForSeconds(5f);
        agent.isStopped = true;
    }
    private void Update()
    {
        //Set target dynamically
        agent.SetDestination(target.position);
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
                targetFOV = minFOV; // 20
                break;
            default:
                targetFOV = minFOV; // 20
                break;
        }
        vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, targetFOV, sensibility * Time.deltaTime);
    }
    
}
