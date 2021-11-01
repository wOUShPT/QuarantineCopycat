using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CinemachineSwitcher : MonoBehaviour
{
    private Animator animator;
    private CinemachineStateDrivenCamera stateDrivenCamera;
    
    public enum CinemachineStateSwitcher
    {
        FirstPerson, SecondPerson, Darts, Toilet, Bath, BrushTeeth, WateringCan
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
                    //Debug.Log("Extension Found : " + extension);
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
    
    public void ChangeToToilet()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.Toilet;
        SwitchState();
    }
    
    public void ChangeToBath()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.Bath;
        SwitchState();
    }
    public void ChangeToBrushTeeth()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.BrushTeeth;
        SwitchState();
    }
    public void ChangeToWaterinCan()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.WateringCan;
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
            
            case CinemachineStateSwitcher.Toilet:
                ToggleCurrentCinemachineExtension(false);
                animator.Play("ToiletCameraState");
                StartCoroutine(WaitToToToggleCinemachineExtension(true, 0f));
                //fPExtension.IsFirstPerson = true;
                break;
            
            case CinemachineStateSwitcher.Bath:
                ToggleCurrentCinemachineExtension(false);
                animator.Play("BathCameraState");
                StartCoroutine(WaitToToToggleCinemachineExtension(true, 0f));
                //fPExtension.IsFirstPerson = true;
                break;
            case CinemachineStateSwitcher.BrushTeeth:
                ToggleCurrentCinemachineExtension(false);
                animator.Play("BrushTeethState");
                StartCoroutine(WaitToToToggleCinemachineExtension(true, 0f));
                break;
            case CinemachineStateSwitcher.WateringCan:
                ToggleCurrentCinemachineExtension(false);
                animator.Play("WateringCanState");
                StartCoroutine(WaitToToToggleCinemachineExtension(true, 0f));
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
