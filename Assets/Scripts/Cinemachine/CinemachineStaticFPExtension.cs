using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineStaticFPExtension : CinemachineExtension
{
    public float horizontalSpeed;
 
    public float verticalSpeed;
    
    public bool isClampedOnXAxis;
    
    public Vector2 clampXViewAngle;
    
    public bool isClampedOnYAxis;
    
    public Vector2 clampYViewAngle;

    private Transform _pivotTransform;

    [SerializeField]
    private Vector3 _currentRotation;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vCameraBase, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (!PlayerProperties.FreezeAim)
        {
            _currentRotation.x += InputManager.Instance.PlayerInput.Look.x * verticalSpeed * deltaTime;
            _currentRotation.y += InputManager.Instance.PlayerInput.Look.y * horizontalSpeed * deltaTime;
            _currentRotation.z = 0;
        }
        else
        {
            _currentRotation = vCameraBase.Follow.rotation.eulerAngles;
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

        var followRotation = vCameraBase.Follow.rotation;
                
        state.RawOrientation = Quaternion.Euler(followRotation.eulerAngles.x - _currentRotation.y,
            followRotation.eulerAngles.y + _currentRotation.x, 0);

    }
}
