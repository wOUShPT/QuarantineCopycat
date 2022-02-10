using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CinemachineFPExtension : CinemachineExtension
{
    public MouseSettings mouseSettingsData;
    
    public float horizontalSpeed;
 
    public float verticalSpeed;
    
    public bool isClampedOnXAxis;
    
    public Vector2 clampXViewAngle;
    
    public bool isClampedOnYAxis;
    
    public Vector2 clampYViewAngle;

    private CinemachineVirtualCameraBase vCam;
    
    private Transform _pivotTransform;

    [SerializeField]
    private Vector3 _currentRotation;

    private static bool isFirstPerson = true;

    private CinemachineFPCutsceneExtension _cinemachineFpCutsceneExtension;

    public bool IsFirstPerson
    {
        get => isFirstPerson;
        set => isFirstPerson = value;
    }

    public Vector3 CurrentRotation
    {
        get => _currentRotation;
        set
        {
            if (PlayerProperties.Mode == PlayerProperties.State.Cutscene)
            {
                _currentRotation = value;  
            }
        } 
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _cinemachineFpCutsceneExtension = FindObjectOfType<CinemachineFPCutsceneExtension>();
        vCam = GetComponent<CinemachineVirtualCameraBase>();
        _currentRotation = vCam.Follow.localRotation.eulerAngles;
        _currentRotation.z = 0;
        CameraState state = vCam.State;
        Debug.Log(_currentRotation);
        state.RawOrientation = Quaternion.Euler(_currentRotation);
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vCameraBase, CinemachineCore.Stage stage,
        ref CameraState state, float deltaTime)
    {
        if (PlayerProperties.Mode == PlayerProperties.State.Dynamic)
        {
            if (!PlayerProperties.FreezeAim)
            {
                _currentRotation.x += InputManager.Instance.PlayerInput.Look.x * mouseSettingsData.mouseSensitivity * deltaTime;
                _currentRotation.y += InputManager.Instance.PlayerInput.Look.y * mouseSettingsData.mouseSensitivity * deltaTime;
                _currentRotation.z = 0;
            }

            if (isClampedOnXAxis)
            {
                _currentRotation.x = Mathf.Clamp(_currentRotation.x, clampXViewAngle.x, clampXViewAngle.y);
            }

            if (isClampedOnYAxis)
            {
                _currentRotation.y = Mathf.Clamp(_currentRotation.y, clampYViewAngle.x, clampYViewAngle.y);
            }

            state.RawOrientation = Quaternion.Euler(-_currentRotation.y, _currentRotation.x, 0);
                
        }
        else
        {
            _currentRotation = _cinemachineFpCutsceneExtension.CurrentRotation;
        }
    }

    public void RecenterYAxis()
    {
        StartCoroutine(RecenterYAxisLerp(1f));

    }

    IEnumerator RecenterYAxisLerp(float duration)
    {
        float timeElapsed = 0;
        while (_currentRotation.y != 0)
        {
            timeElapsed += Time.deltaTime;
            _currentRotation.y = Mathf.Lerp(_currentRotation.y, 0, timeElapsed / duration);
            vCam.ForceCameraPosition(vCam.Follow.position, Quaternion.Euler(_currentRotation));
            yield return null;
        }
    }


    

    
}
