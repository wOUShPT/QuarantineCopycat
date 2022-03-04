using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Cinemachine;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _turnSpeed;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private Transform cameraPivot;
    [SerializeField, Range(0,1.5f)] 
    private float headBobIntensity;
    [SerializeField] 
    private float headBobSpeed;
    [SerializeField] 
    private CinemachineFPExtension _cinemachineFpExtension;
    private CinemachineStateDrivenCamera _cinemachineStateDrivenCamera;
    private Camera _camera;
    public bool isOnActionPivot;
    private Vector3 _currentMoveDirection;
    private Vector3 _currentRotation;
    private Vector3 _startHeadPosition;
    private Vector3 _currentHeadPosition;
    private float _headBobTimeCounter;

    public float currentVelocity => new Vector2(_characterController.velocity.x, _characterController.velocity.z).magnitude;
    
    void Awake()
    {
        _cinemachineStateDrivenCamera = FindObjectOfType<CinemachineStateDrivenCamera>();
        _camera = Camera.main;
        isOnActionPivot = false;
        _currentHeadPosition = cameraPivot.localPosition;
        _startHeadPosition = _currentHeadPosition;
        _headBobTimeCounter = 0;
    }
    
    void Update()
    {
        if (PlayerProperties.FreezeMovement)
        {
            return;
        }
        
        UpdateRotation();
        UpdateMovement();
        UpdateHeadPosition();
    }
    

    void UpdateMovement()
    {
        _currentMoveDirection = (transform.forward * InputManager.Instance.PlayerInput.Movement.z) + (transform.right * InputManager.Instance.PlayerInput.Movement.x);
        _currentMoveDirection += new Vector3(_currentMoveDirection.x , gravity, _currentMoveDirection.z);
        _characterController.Move(_currentMoveDirection * _movementSpeed * Time.deltaTime);
        
    }

    void UpdateRotation()
    {
        if (PlayerProperties.Mode == PlayerProperties.State.Cutscene && CameraManager.CinemachineCameraState != CameraManager.CinemachineStateSwitcher.FirstPerson)
        {
            return;
        }

        transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, _camera.transform.localRotation.eulerAngles.y, 0)), _turnSpeed * Time.deltaTime);
    }

    // update head bobbing
    void UpdateHeadPosition()
    {
        if (_currentMoveDirection.x != 0 || _currentMoveDirection.z != 0)
        {
            _currentHeadPosition.y = _startHeadPosition.y - Mathf.PingPong(Time.time * headBobSpeed, headBobIntensity*0.1f);
        }
        else
        {
            _headBobTimeCounter = 0;
            _currentHeadPosition.y = Mathf.Lerp(cameraPivot.transform.localPosition.y, _startHeadPosition.y, Time.deltaTime * 20f);
        }

        cameraPivot.transform.localPosition = _currentHeadPosition;
    }

    public void ToggleCollision(bool state)
    {
        _characterController.enableOverlapRecovery = state;
    }


    // call cinemachine custom extension to recenter the camera on the Y Axis
    public void CenterCameraOnYAxis()
    {
        _cinemachineFpExtension.RecenterYAxis();
    }
}
