using System;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using STOP_MODE = FMOD.Studio.STOP_MODE;

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
    [SerializeField] private SkinnedMeshRenderer copycatMeshRenderer;
    [SerializeField] private Animator fpCopycatAnimator;
    [SerializeField] private Animator copycatAnimator;
    [SerializeField] private LayerMask chaseMask;
    private PlayerSPRotate playerRotate;
    [SerializeField] private CameraFunctions playerCameraFunctions;
    [SerializeField] private GameEvent dollyEvent;
    [SerializeField] private CinemachineVirtualCamera firstVirtualCamera;
    private FPCameraHandler _fpCameraHandler;
    private float initialFOVVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera secondVirtualCamera;
    [SerializeField] private Transform fpTransitionLookAt;
    private CinemachinePOV fpCameraPOVComponent;
    private CinemachineComposer spCameraComposer;
    private float fpInitialFrustumHeight;
    private float spInitialFrustumHeight;
    public EventReference copycatAmbient;
    private EventInstance _copycatEventInstance;
    [SerializeField] private CanvasGroup gameoverGroup;
    [SerializeField] private float waitJellyEffectSeconds = 4f;
    [SerializeField] private float waitFadeInSeconds = 1f;
    [SerializeField] private float waitSetupSeconds = .1f;
    [SerializeField] private float endFOVValue = 40f;
    [SerializeField] private float lerpDuration = 1.5f;
    [SerializeField] private float FadeCameraPassToSecondPersonTime = 0.9f;
    [SerializeField] private EventReference chaseTriggerEventReference;
    private EventInstance chasetriggerEventInstance;
    private delegate void DollyZoomEffect();
    private DollyZoomEffect zoomEffect;
    [SerializeField] private Volume copycatVisionVolume;
    private CopycatVision _copycatVision;
    [SerializeField] private Animator sceneTransitionAnimator;
    private void Awake()
    {
        //Need to put in inspector
        aiChase = FindObjectOfType<AIChase>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        cameraManager = FindObjectOfType<CameraManager>();
        triggerChaseArray = FindObjectsOfType<TriggerChase>();
        playerRotate = FindObjectOfType<PlayerSPRotate>();
        _fpCameraHandler = firstVirtualCamera.GetComponent<FPCameraHandler>();
        fpCameraPOVComponent = firstVirtualCamera.GetCinemachineComponent<CinemachinePOV>();
        spCameraComposer = secondVirtualCamera.GetCinemachineComponent<CinemachineComposer>();
        if (copycatVisionVolume.profile.TryGet(out CopycatVision copycatVisionTemp))
        {
            _copycatVision = copycatVisionTemp;
        }

        chasetriggerEventInstance = RuntimeManager.CreateInstance(chaseTriggerEventReference);

    }
    private void Start()
    {
        copycatVisionVolume.enabled = false;
        savedLayerMask = Camera.main.cullingMask;
        SetEnableDisableSecondPersonRotate(false);
        initialFOVVirtualCamera = firstVirtualCamera.m_Lens.FieldOfView;
        _copycatEventInstance = FMODUnity.RuntimeManager.CreateInstance(copycatAmbient);
        foreach (var trigger in triggerChaseArray)
        {
            trigger.OnPlayerInsideTrigger += ColliderTrigger_OnPlayerEnterTrigger;
        }
        // Disable gameover group of gameover's canvas
        gameoverGroup.alpha = 0f;
        gameoverGroup.interactable = false;
        gameoverGroup.blocksRaycasts = false;
        SetFreezePlayerProperties(false, false, false);
        copycatMeshRenderer.enabled = false;
        //SetupFirstPersonAgain();
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
        copycatMeshRenderer.enabled = true;
        InputManager.Instance.TogglePlayerControls(false);
        fpCameraPOVComponent.m_VerticalAxis.m_InputAxisValue = 0;
        fpCameraPOVComponent.m_HorizontalAxis.m_InputAxisValue = 0;
        Vector3 enemyEuler = aiChase.transform.rotation.eulerAngles;
        aiChase.transform.LookAt(firstVirtualCamera.transform);
        aiChase.transform.rotation = Quaternion.Euler(enemyEuler.x, aiChase.transform.eulerAngles.y, enemyEuler.z);
        fpCopycatAnimator.Rebind();
        fpCopycatAnimator.Update(0);
        copycatAnimator.SetTrigger("Spawn");
        Camera.main.cullingMask = seeCopycatMask;
        //Stop player
        SetFreezePlayerProperties(true, true, true);
        playerCameraFunctions.ResetCameraTransform();
        if (waitTimeToSwitchCamera > 1)
        {
            chasetriggerEventInstance.start();
        }
        yield return new WaitForSeconds(waitTimeToSwitchCamera);
        dollyEvent.Raise();
        SetupDolly();
        //Fade camera and pass to second person
        yield return new WaitForSeconds(FadeCameraPassToSecondPersonTime);
        copycatAnimator.Rebind();
        copycatAnimator.Update(0);
        fpTransitionLookAt = secondVirtualCamera.LookAt;
        fpTransitionLookAt.position += (firstVirtualCamera.transform.position - secondVirtualCamera.transform.position).normalized * 2f;
        firstVirtualCamera.LookAt = fpTransitionLookAt;
        Camera.main.cullingMask = chaseMask;
        cameraManager.SwitchCamera(CameraManager.CinemachineStateSwitcher.SecondPerson);
        UIManager.Instance.ToggleReticle(false);
        copycatVisionVolume.enabled = true;
        yield return new WaitForSeconds(waitJellyEffectSeconds);
        zoomEffect -= DollyZoom;
        //Reset
        playerRotate.transform.localRotation = Quaternion.Euler(Vector3.zero);
        yield return new WaitForSeconds(waitSetupSeconds);
        float timeElapsed = 0f;
        float startFOVValue = secondVirtualCamera.m_Lens.FieldOfView;
        while (timeElapsed < lerpDuration)
        {
            secondVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(startFOVValue, endFOVValue, timeElapsed / lerpDuration);
            _copycatVision.blend.value = Mathf.Lerp(0, 1, timeElapsed / lerpDuration);
            secondVirtualCamera.m_Lens.ShutterSpeed = 10;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        secondVirtualCamera.m_Lens.FieldOfView = endFOVValue;
        fpCopycatAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(waitSetupSeconds);
        InputManager.Instance.TogglePlayerControls(true);
        aiChase.Agent.enabled = true;
        aiChase.Agent.isStopped = false; // Copycat starts moving
        SetEnableDisableSecondPersonRotate(true);
        _copycatEventInstance.start();
        SetFreezePlayerProperties(true, true, false);
        aiChase.SetWaypoint();
        aiChase.SetCurrentTimeToChangeMoveMax();
        aiChase.State = AIChase.AgentState.Chase;
    }
    private void SetFreezePlayerProperties(bool stateAim, bool stateInteraction, bool stateMovement)
    {
        PlayerProperties.FreezeAim = stateAim;
        PlayerProperties.FreezeInteraction = stateInteraction;
        PlayerProperties.FreezeMovement = stateMovement;
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
        zoomEffect += DollyZoom;
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
        SetFreezePlayerProperties(true, true, true);
        playerRotate.transform.rotation = playerMovement.transform.rotation;
        SetEnableDisableSecondPersonRotate(false);
        dollyEvent.Raise();
        _fpCameraHandler.MoveCameraOnYaw(0, 0);
        yield return new WaitForSeconds(waitFadeInSeconds);
        firstVirtualCamera.LookAt = null;
        _copycatEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
        copycatMeshRenderer.enabled = false;
        UIManager.Instance.ToggleReticle(true);
        copycatVisionVolume.enabled = false;
        firstVirtualCamera.m_Lens.FieldOfView = initialFOVVirtualCamera;
        Camera.main.cullingMask = savedLayerMask;
        cameraManager.SwitchCamera(CameraManager.CinemachineStateSwitcher.FirstPerson);
        SetFreezePlayerProperties(false, false, false);
        _copycatVision.blend.value = 0;
    }
    private void Update()
    {
        zoomEffect?.Invoke();
    }
    private void DollyZoom()
    {
        var currDistance = Vector3.Distance(Camera.main.transform.position, playerMovement.transform.position);
        firstVirtualCamera.m_Lens.FieldOfView = ComputeFieldOfView(fpInitialFrustumHeight, currDistance);
        secondVirtualCamera.m_Lens.FieldOfView = ComputeFieldOfView(spInitialFrustumHeight, currDistance);
    }
    public void SetEnableDisableSecondPersonRotate(bool state)
    {
        playerRotate.enabled = state;
    }
    public void EnableGameOverScreen()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        sceneTransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Labyrinth");
    }

    private void OnDestroy()
    {
        _copycatEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _copycatEventInstance.release();
    }
}
