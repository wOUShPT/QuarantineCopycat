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

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private Transform cameraPivot;
    [SerializeField] 
    private NavMeshAgent _agent;
    [SerializeField, Range(0,1.5f)] 
    private float headBobIntensity;
    [SerializeField] 
    private float headBobSpeed;
    public bool isOnActionPivot;
    private Vector3 _currentMoveDirection;
    private Vector3 _currentRotation;
    private Vector3 _startHeadPosition;
    private Vector3 _currentHeadPosition;
    private float _headBobTimeCounter;
    
    void Awake()
    {
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
        _characterController.Move(_currentMoveDirection * movementSpeed * Time.deltaTime);
        
    }

    void UpdateRotation()
    {
        _currentRotation = new Vector3(0, Camera.main.transform.localRotation.eulerAngles.y, 0);
        transform.localEulerAngles = _currentRotation;
    }

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

    private IEnumerator MoveToTargetCoroutine(Transform target, float distanceThreshold)
    {
        _agent.SetDestination(target.position);
        yield return new WaitUntil(() => Vector3.Distance(transform.position, target.position) <= _agent.stoppingDistance + distanceThreshold);
        while (Mathf.Abs(_currentRotation.y - target.rotation.eulerAngles.y) >= 0.005f)
        {
            _currentRotation.y = Mathf.Lerp(_currentRotation.y, target.rotation.eulerAngles.y, Time.deltaTime * 3f);
            transform.rotation = Quaternion.Euler(_currentRotation);
            yield return null;
        }
        isOnActionPivot = true;
    }

    public void MoveToTarget(Transform target, float distanceThreshold)
    {
        PlayerProperties.FreezeMovement = true;
        PlayerProperties.FreezeAim = true;
        PlayerProperties.FreezeInteraction = true;
        StartCoroutine(MoveToTargetCoroutine(target, distanceThreshold));
    }
}
