using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CinemachineFPExtension : CinemachineExtension
{
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField] 
    private float verticalSpeed;
    [SerializeField]
    private float clampXViewAngle;
    [SerializeField]
    private float clampYViewAngle;

    [SerializeField]
    private bool isCameraFixed;

    private Vector3 _currentRotation;

    private Quaternion _currentRawOrientation;

    private static bool isFirstPerson = true;
    public bool IsFirstPerson { get { return isFirstPerson; } set { isFirstPerson = value; } }

    protected override void Awake()
    {
        base.Awake();
        _currentRotation = Vector3.zero;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _currentRotation = Vector3.zero;
        CinemachineVirtualCameraBase vCam = GetComponent<CinemachineVirtualCameraBase>();
        vCam.ForceCameraPosition(vCam.Follow.position, vCam.Follow.rotation);
        _currentRawOrientation = vCam.State.RawOrientation;
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vCam, CinemachineCore.Stage stage,
        ref CameraState state, float deltaTime)
    {

        if (!PlayerProperties.FreezeAim)
        {
            _currentRotation.x += InputManager.Instance.PlayerInput.Look.x * verticalSpeed * Time.deltaTime;
            _currentRotation.y += InputManager.Instance.PlayerInput.Look.y * horizontalSpeed * Time.deltaTime;
            
            if (clampXViewAngle != 0)
            {
                _currentRotation.x = Mathf.Clamp(_currentRotation.x, -clampXViewAngle, clampXViewAngle);
            }

            _currentRotation.y = Mathf.Clamp(_currentRotation.y, -clampYViewAngle, clampYViewAngle);

            if (isCameraFixed)
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

            state.RawOrientation = _currentRawOrientation;

        }
    }
}
