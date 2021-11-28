using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

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
    
    private Vector3 _currentMoveDirection;
    private Vector3 _currentRotation;
    private Vector3 _startHeadPosition;
    private Vector3 _currentHeadPosition;
    private float _headBobTimeCounter;
    
    void Awake()
    {
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
            _currentHeadPosition.y = _startHeadPosition.y - Mathf.PingPong(Time.time * 0.5f, 0.15f);
        }
        else
        {
            _headBobTimeCounter = 0;
            _currentHeadPosition.y = Mathf.Lerp(cameraPivot.transform.localPosition.y, _startHeadPosition.y, Time.deltaTime * 20f);
        }

        cameraPivot.transform.localPosition = _currentHeadPosition;
    }
}
