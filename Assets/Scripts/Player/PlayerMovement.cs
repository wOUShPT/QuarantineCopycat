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
    private float sprintSpeed;
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
    [SerializeField] private bool canSprint = false;
    [SerializeField] private CameraManager cameraManager;
    private Camera _camera;
    public bool isOnActionPivot;
    private Vector3 _currentMoveDirection;
    public Vector3 CurrentMoveDirection => _currentMoveDirection;
    private Vector3 _startHeadPosition;
    private Vector3 _currentHeadPosition;
    [Range(0f, 3f)] [SerializeField] private float headPositionMultiplier = 0.3f;
    private float _headBobTimeCounter;
    public float currentVelocity => new Vector2(_currentMoveDirection.x, _currentMoveDirection.z).magnitude;
    
    void Awake()
    {
        _camera = Camera.main;
        isOnActionPivot = false;
        _currentHeadPosition = cameraPivot.localPosition;
        _startHeadPosition = _currentHeadPosition;
        _headBobTimeCounter = 0;
        if (canSprint)
        {
            PlayerProperties.FreezeMovement = false;
            cameraManager.ChangeToFirst();
        }
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
        if(CameraManager.CinemachineCameraState != CameraManager.CinemachineStateSwitcher.SecondPerson)
        {
            _currentMoveDirection = (transform.forward * InputManager.Instance.PlayerInput.Movement.z) + (transform.right * InputManager.Instance.PlayerInput.Movement.x);
            _currentMoveDirection += new Vector3(_currentMoveDirection.x, gravity, _currentMoveDirection.z);
        }
        if(CameraManager.CinemachineCameraState == CameraManager.CinemachineStateSwitcher.SecondPerson)
        {
            _currentMoveDirection = (Camera.main.transform.forward * Mathf.Clamp01(InputManager.Instance.PlayerInput.Movement.z)) + (Camera.main.transform.right * InputManager.Instance.PlayerInput.Movement.x);
            if (_currentMoveDirection == Vector3.zero)
            {
                return;
            }
            _currentMoveDirection += new Vector3(_currentMoveDirection.x, gravity, _currentMoveDirection.z);
        }
        _characterController.Move(_currentMoveDirection * (canSprint && GetIsSprinting() ? sprintSpeed : _movementSpeed) * Time.deltaTime);
        
    }

    void UpdateRotation()
    {
        if (PlayerProperties.Mode == PlayerProperties.State.Cutscene)
        {
            return;
        }
        if(CameraManager.CinemachineCameraState != CameraManager.CinemachineStateSwitcher.FirstPerson)
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
            if (canSprint && InputManager.Instance.PlayerInput.isSprinting)
            {
                _currentHeadPosition.y = _startHeadPosition.y - Mathf.PingPong(Time.time * headBobSpeed * (headBobIntensity * headPositionMultiplier), headBobIntensity * 0.1f);
            }
            else
            {
                _currentHeadPosition.y = _startHeadPosition.y - Mathf.PingPong(Time.time * headBobSpeed, headBobIntensity * 0.1f);
            }     
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
    public bool GetIsSprinting()
    {
        if (PlayerProperties.FreezeMovement)
        {
            return false;
        }
        return InputManager.Instance.PlayerInput.isSprinting;
    }
}
