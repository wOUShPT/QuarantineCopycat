using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineFPExtension : CinemachineExtension
{
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField] 
    private float verticalSpeed;
    [SerializeField]
    private float clampViewAngle;
    
    private Vector3 _currentRotation;

    private static bool isFirstPerson = true;
    public bool IsFirstPerson { get { return isFirstPerson; } set { isFirstPerson = value; } }

    protected override void Awake()
    {
        _currentRotation = Vector3.zero;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow && IsFirstPerson)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (_currentRotation == null)
                {
                    _currentRotation = transform.localRotation.eulerAngles;
                }

                _currentRotation.x += InputManager.Instance.PlayerInput.Look.x * verticalSpeed * Time.deltaTime;
                _currentRotation.y += InputManager.Instance.PlayerInput.Look.y * horizontalSpeed * Time.deltaTime;
                _currentRotation.y = Mathf.Clamp(_currentRotation.y, -clampViewAngle, clampViewAngle);
                state.RawOrientation = Quaternion.Euler(-_currentRotation.y, _currentRotation.x, 0);
            }
        }
    }
}
