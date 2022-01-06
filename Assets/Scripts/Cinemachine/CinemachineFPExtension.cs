using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CinemachineFPExtension : CinemachineExtension
{
    [SerializeField] private CameraMode mode;
    
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField] 
    private float verticalSpeed;
    [SerializeField]
    private float clampXViewAngle;
    [SerializeField]
    private float clampYViewAngle;

    private CinemachineVirtualCameraBase vCam;
    private Transform _pivotTransform;

    private Vector3 _currentRotation = Vector3.zero;

    private static bool isFirstPerson = true;

    public bool IsFirstPerson
    {
        get => isFirstPerson;
        set => isFirstPerson = value;
    }

    public Vector3 CurrentRotation => _currentRotation;

    public CameraMode Mode
    {
        get => mode;
        set => mode = value;
    }

    protected override void Awake()
    {
        base.Awake();
        vCam = GetComponent<CinemachineVirtualCameraBase>();
        _currentRotation = vCam.Follow.rotation.eulerAngles;
        _currentRotation.z = 0;
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vCam, CinemachineCore.Stage stage,
        ref CameraState state, float deltaTime)
    {
        
        switch (mode)
        {
            case CameraMode.Dynamic:

                if (!PlayerProperties.FreezeAim)
                {
                    _currentRotation.x += InputManager.Instance.PlayerInput.Look.x * verticalSpeed * deltaTime;
                    _currentRotation.y += InputManager.Instance.PlayerInput.Look.y * horizontalSpeed * deltaTime;
                    _currentRotation.z = 0;
            
                    if (clampXViewAngle != 0)
                    {
                        _currentRotation.x = Mathf.Clamp(_currentRotation.x, -clampXViewAngle, clampXViewAngle);
                    }

                    _currentRotation.y = Mathf.Clamp(_currentRotation.y, -clampYViewAngle, clampYViewAngle);
                
                    state.RawOrientation = Quaternion.Euler(-_currentRotation.y, _currentRotation.x, 0);
                }
                else
                {
                    _currentRotation = vCam.Follow.rotation.eulerAngles;
                    _currentRotation.z = 0;
                    state.RawOrientation = Quaternion.Euler(_currentRotation);
                }
                
                break;
            
            case CameraMode.Static:
                
                _currentRotation.x += InputManager.Instance.PlayerInput.Look.x * verticalSpeed * deltaTime;
                _currentRotation.y += InputManager.Instance.PlayerInput.Look.y * horizontalSpeed * deltaTime;
                _currentRotation.z = 0;
            
                if (clampXViewAngle != 0)
                {
                    _currentRotation.x = Mathf.Clamp(_currentRotation.x, -clampXViewAngle, clampXViewAngle);
                }

                _currentRotation.y = Mathf.Clamp(_currentRotation.y, -clampYViewAngle, clampYViewAngle);
                
                state.RawOrientation = Quaternion.Euler(vCam.Follow.rotation.eulerAngles.x - _currentRotation.y, vCam.Follow.rotation.eulerAngles.y + _currentRotation.x, 0);
                
                /*
                _currentRotation.x = vCam.Follow.rotation.eulerAngles.x;
                _currentRotation.y = vCam.Follow.rotation.eulerAngles.y;
                state.RawOrientation = Quaternion.Euler(_currentRotation);
                */
                
                break;
            
            case CameraMode.Cutscene:
                
                _currentRotation = Quaternion.LookRotation((vCam.LookAt.position - vCam.Follow.position).normalized).eulerAngles;
                
                state.RawOrientation = Quaternion.Euler(_currentRotation.x, _currentRotation.y, vCam.LookAt.rotation.eulerAngles.z);

                break;
        }

        /*if (!PlayerProperties.FreezeAim)
        {
            _currentRotation.x += InputManager.Instance.PlayerInput.Look.x * verticalSpeed * Time.deltaTime;
            _currentRotation.y += InputManager.Instance.PlayerInput.Look.y * horizontalSpeed * Time.deltaTime;
            
            if (clampXViewAngle != 0)
            {
                _currentRotation.x = Mathf.Clamp(_currentRotation.x, -clampXViewAngle, clampXViewAngle);
            }

            _currentRotation.y = Mathf.Clamp(_currentRotation.y, -clampYViewAngle, clampYViewAngle);

            if (mode == CameraMode.Static)
            {
                state.RawOrientation = Quaternion.Euler(vCam.Follow.rotation.eulerAngles.x - _currentRotation.y, vCam.Follow.rotation.eulerAngles.y + _currentRotation.x, 0);
            }
            else
            {
                state.RawOrientation = Quaternion.Euler(-_currentRotation.y, _currentRotation.x, 0);
            }

            _currentRawOrientation = state.RawOrientation;
        }
        else
        {
            _currentRawOrientation = vCam.Follow.rotation;
            _currentRotation.x = vCam.Follow.rotation.eulerAngles.y;
            _currentRotation.y = vCam.Follow.rotation.eulerAngles.x;
            state.RawOrientation = _currentRawOrientation;
        }
        */
    }

    public void RecenterYAxis()
    {
        StartCoroutine(RecenterYAxisLerp(1f));

    }

    IEnumerator RecenterYAxisLerp(float duration)
    {
        float timeElapsed = 0;
        float startRotationOnY = _currentRotation.y;
        while (_currentRotation.y != 0)
        {
            timeElapsed += Time.deltaTime;
            _currentRotation.y = Mathf.Lerp(_currentRotation.y, 0, timeElapsed / duration);
            vCam.ForceCameraPosition(vCam.Follow.position, Quaternion.Euler(_currentRotation));
            yield return null;
        }
    }


    public enum CameraMode
    {
        Dynamic,
        Cutscene,
        Static
    }

    public void SwitchToCutsceneMode()
    {
        mode = CameraMode.Cutscene;
    }

    public void SwitchToDynamicMode()
    {
        mode = CameraMode.Dynamic;
    }

    public void SwitchToStaticMode()
    {
        mode = CameraMode.Static;
    }
}
