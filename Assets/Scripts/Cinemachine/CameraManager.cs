using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraManager : MonoBehaviour
{
    private Animator animator;
    private CinemachineStateDrivenCamera stateDrivenCamera;

    public List<InteractableBehaviour> Interactables;

    [Serializable]
    public enum CinemachineStateSwitcher
    {
        FirstPerson, Cinematic, SecondPerson, Darts, Toilet, Bath, BrushTeeth, WateringCan, Cadre, Sofa, Copycat
    }
    private static CinemachineStateSwitcher cinemachineSwitcher;
    private CinemachineExtension[] _cameraExtensions;
    private CinemachineVirtualCameraBase[] _cameras;

    public static CinemachineStateSwitcher CinemachineCameraState => cinemachineSwitcher;
    
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
    
    public void ChangeToCinematic()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.Cinematic;
        SwitchState();
    }
    
    public void ChangeToSecond()
    {
        Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
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

    public void ChangeToFirstCadre()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.Cadre;
        SwitchState();
    }

    public void ChangeToSofa()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.Sofa;
        SwitchState();
    }
    
    public void SwitchCamera(CinemachineStateSwitcher state)
    {
        cinemachineSwitcher = state;
        SwitchState();
    }
    public void ChangeWatchCopycat()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.Copycat;
        SwitchState();
    }
    
    private void SwitchState()
    {
        switch (cinemachineSwitcher)
        {
            case CinemachineStateSwitcher.FirstPerson:
                animator.Play("FPCameraState");
                break;
            
            case CinemachineStateSwitcher.Cinematic:
                animator.Play("FPCameraState");
                break;

            case CinemachineStateSwitcher.SecondPerson:
                animator.Play("SPCameraState");
                break;
            
            case CinemachineStateSwitcher.Darts:
                animator.Play("DartsCameraState");
                break;
            
            case CinemachineStateSwitcher.Toilet:
                animator.Play("ToiletCameraState");
                break;
            
            case CinemachineStateSwitcher.Bath:
                animator.Play("BathCameraState");
                break;
            case CinemachineStateSwitcher.BrushTeeth:
                animator.Play("BrushTeethState");
                break;
            case CinemachineStateSwitcher.WateringCan:
                animator.Play("WateringCanState");
                break;
            case CinemachineStateSwitcher.Cadre:
                animator.Play("CadreState");
                break;
            
            case CinemachineStateSwitcher.Sofa:
                animator.Play("SofaState");
                break;
            case CinemachineStateSwitcher.Copycat:
                animator.Play("CopycatState");
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
