using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseManager : MonoBehaviour
{
    private AIChase aiChase;
    private PlayerMovement playerMovement;
    private CameraManager cameraManager;
    private TriggerChase[] triggerChaseArray;
    private LayerMask savedLayerMask;
    //Chase setup
    private float waitTimeToSwitchCamera = 5.0f;
    [SerializeField] private LayerMask seeCopycatMask;
    [SerializeField] private LayerMask chaseMask;
    private PlayerSPRotate playerRotate;
    [SerializeField] private CameraFunctions playerCameraFunctions;
    [SerializeField] private GameEvent dollyEvent;
    [SerializeField] private CinemachineVirtualCamera firstVirtualCamera;
    private float initialFOVVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera secondVirtualCamera;
    private float fpInitialFrustumHeight;
    private float spInitialFrustumHeight;
    private bool dollyzoomEnabled = false;
    [SerializeField] private CanvasGroup gameoverGroup;
    [SerializeField] private float waitJellyEffectSeconds = 4f;
    [SerializeField] private float waitFadeInSeconds = 1f;
    [SerializeField] private float waitMinimum = .1f;
    private void Awake()
    {
        aiChase = FindObjectOfType<AIChase>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        cameraManager = FindObjectOfType<CameraManager>();
        triggerChaseArray = FindObjectsOfType<TriggerChase>();
        playerRotate = FindObjectOfType<PlayerSPRotate>();
    }
    private void Start()
    {
        savedLayerMask = Camera.main.cullingMask;
        SetEnableDisableSecondPersonRotatee(false);
        initialFOVVirtualCamera = firstVirtualCamera.m_Lens.FieldOfView;
        foreach (var trigger in triggerChaseArray)
        {
            trigger.OnPlayerInsideTrigger += ColliderTrigger_OnPlayerEnterTrigger;
        }
        // Disable gameover group of gameover's canvas
        gameoverGroup.alpha = 0f;
        gameoverGroup.interactable = false;
        gameoverGroup.blocksRaycasts = false;
    }
    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        SwitchToSecondCamera();
    }
    private void SwitchToSecondCamera()
    {
        StartCoroutine(SetupChase());
    }
    IEnumerator SetupChase()
    {
        Camera.main.cullingMask = seeCopycatMask;
        //Stop player
        PlayerProperties.FreezeAim = true;
        PlayerProperties.FreezeInteraction = true;
        PlayerProperties.FreezeMovement = true;
        playerCameraFunctions.ResetCameraTransform();
        yield return new WaitForSeconds(waitTimeToSwitchCamera);
        dollyEvent.Raise();
        SetupDolly();
        yield return new WaitForSeconds(.9f);
        Camera.main.cullingMask = chaseMask;
        cameraManager.SwitchCamera(CameraManager.CinemachineStateSwitcher.SecondPerson);
        UIManager.Instance.ToggleReticle(false);
        yield return new WaitForSeconds(waitJellyEffectSeconds);
        dollyzoomEnabled = false;
        yield return new WaitForSeconds(waitMinimum);
        float timeElapsed = 0f;
        float lerpDuration = 2f;
        float startValue = secondVirtualCamera.m_Lens.FieldOfView;
        float endValue = 40f;
        while (timeElapsed < lerpDuration)
        {
            secondVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        secondVirtualCamera.m_Lens.FieldOfView = endValue;
        yield return new WaitForSeconds(waitMinimum);
        aiChase.Agent.enabled = true;
        aiChase.Agent.isStopped = false; // Copycat starts moving
        SetEnableDisableSecondPersonRotatee(true);
        PlayerProperties.FreezeMovement = false;
        aiChase.SetWaypoint();
        aiChase.SetCurrentTimeToChangeMoveMax();
        aiChase.State = AIChase.AgentState.Chase;
    }
    // Calculate the frustum height at a given distance from the camera.
    private float FrustumHeightAtDistance(float distance, CinemachineVirtualCamera camera)
    {
        return 2.0f * distance * Mathf.Tan(camera.m_Lens.FieldOfView * 0.5f * Mathf.Deg2Rad);
    }
    private float ComputeFieldOfView(float height, float distance)
    {
        // Calculate the FOV needed to get a given frustum height at a given distance.
        return 2.0f * Mathf.Atan((float)(height * 0.5 / distance)) * Mathf.Rad2Deg;
    }
    private void SetupDolly()
    {
        //Player movement is the target object
        float distanceFromTarget = Vector3.Distance(Camera.main.transform.position, playerMovement.transform.position);

        fpInitialFrustumHeight = FrustumHeightAtDistance(distanceFromTarget, firstVirtualCamera);
        spInitialFrustumHeight = FrustumHeightAtDistance(distanceFromTarget, secondVirtualCamera);
        dollyzoomEnabled = true;
    }
    public void SetTimeToSwitchCamera(float reactCopycatTime)
    {
        waitTimeToSwitchCamera = reactCopycatTime;
    }
    public void SwitchToFirstPerson()
    {
        aiChase.State = AIChase.AgentState.Idle;
        aiChase.Agent.isStopped = true; //Copycat stops moving
        aiChase.Agent.enabled = false;
        StartCoroutine(SetupFirstPersonAgain());
    }
    IEnumerator SetupFirstPersonAgain()
    {
        PlayerProperties.FreezeMovement = true;
        playerRotate.transform.rotation = playerMovement.transform.rotation;
        SetEnableDisableSecondPersonRotatee(false);
        dollyEvent.Raise();
        yield return new WaitForSeconds(waitFadeInSeconds);
        firstVirtualCamera.m_Lens.FieldOfView = initialFOVVirtualCamera;
        Camera.main.cullingMask = savedLayerMask;
        cameraManager.SwitchCamera(CameraManager.CinemachineStateSwitcher.FirstPerson);
        PlayerProperties.FreezeMovement = false;
        PlayerProperties.FreezeAim = false;
    }
    private void Update()
    {
        if (dollyzoomEnabled)
        {
            var currDistance = Vector3.Distance(Camera.main.transform.position, playerMovement.transform.position);
            firstVirtualCamera.m_Lens.FieldOfView = ComputeFieldOfView(fpInitialFrustumHeight, currDistance);
            secondVirtualCamera.m_Lens.FieldOfView = ComputeFieldOfView(spInitialFrustumHeight, currDistance);
        }
    }
    public void SetEnableDisableSecondPersonRotatee(bool state)
    {
        playerRotate.enabled = state;
    }
    public void EnableGameOverScreen()
    {
        Time.timeScale = 1f;
        gameoverGroup.alpha = 1f;
        gameoverGroup.interactable = true;
        gameoverGroup.blocksRaycasts = true;
    }
}
