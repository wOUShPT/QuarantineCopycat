using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction inputAction;
    private Animator animator;
    private CinemachineStateDrivenCamera stateDrivenCamera;
    
    public enum CinemachineStateSwitcher
    {
        FirstPerson, SecondPerson, Darts
    }
    private CinemachineStateSwitcher cinemachineSwitcher;
    private CinemachineExtension[] _cameraExtensions;
    private CinemachineVirtualCameraBase[] _cameras;
    
    private void Awake()
    {
        stateDrivenCamera = GetComponent<CinemachineStateDrivenCamera>();
        if (stateDrivenCamera.ChildCameras.Length != 0)
        {
            _cameras = stateDrivenCamera.ChildCameras;
            _cameraExtensions = new CinemachineExtension[_cameras.Length];
            for (int i = 0; i < _cameras.Length; i++)
            {
                if (_cameras[i].VirtualCameraGameObject.TryGetComponent(out CinemachineExtension extension))
                {
                    _cameraExtensions[i] = extension;
                    #if UNITY_EDITOR
                    Debug.Log("Extension Found : " + extension);
                    #endif
                }
                else
                {
                    _cameraExtensions[i] = null;
                }
            }
        }
        
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputAction.performed += _ => ChangeToDarts(); 
    }
    public void ChangeToFirst()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.FirstPerson;
        SwitchState();
    }
    public void ChangeToSecond()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.SecondPerson;
        SwitchState();
    }

    public void ChangeToDarts()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.Darts;
        SwitchState();
    }

    public void SwitchCamera(CinemachineStateSwitcher state)
    {
        cinemachineSwitcher = state;
        SwitchState();
    }
    
    private void SwitchState()
    {
        switch (cinemachineSwitcher)
        {
            case CinemachineStateSwitcher.FirstPerson:
                ToggleCurrentCinemachineExtension(false);
                animator.Play("FPCameraState");
                StartCoroutine(WaitToToToggleCinemachineExtension(true,0f));
                //fPExtension.IsFirstPerson = true;
                break;
            case CinemachineStateSwitcher.SecondPerson:
                ToggleCurrentCinemachineExtension(false);
                animator.Play("SPCameraState");
                StartCoroutine(WaitToToToggleCinemachineExtension(true,0f));
                //fPExtension.IsFirstPerson = false;
                break;
            
            case CinemachineStateSwitcher.Darts:
                ToggleCurrentCinemachineExtension(false);
                animator.Play("DartsCameraState");
                StartCoroutine(WaitToToToggleCinemachineExtension(true, 0f));
                //fPExtension.IsFirstPerson = true;
                break;
        }
    }

    IEnumerator WaitToToToggleCinemachineExtension(bool state, float delay)
    {
        yield return new WaitForSeconds(delay);
        ToggleCurrentCinemachineExtension(state);
        
    }

    void ToggleCurrentCinemachineExtension(bool state)
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            if (stateDrivenCamera.LiveChild.VirtualCameraGameObject == _cameras[i].VirtualCameraGameObject && _cameraExtensions[i] != null)
            {
                _cameraExtensions[i].enabled = state;
            }
        }
    }
}
