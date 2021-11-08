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
    private CharacterController _characterController;
    [SerializeField] 
    private Transform cameraPivot;
    private Vector3 _headBobPosition;
    private float _headBobTimeCounter;
    
    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _headBobPosition = cameraPivot.localPosition;
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
    }

    void UpdateMovement()
    {
        Vector3 movementDirection = (transform.forward * InputManager.Instance.PlayerInput.Movement.z) + (transform.right * InputManager.Instance.PlayerInput.Movement.x);
        movementDirection += new Vector3(movementDirection.x , gravity, movementDirection.z);
        _characterController.Move(movementDirection * movementSpeed * Time.deltaTime);
        if (movementDirection.x != 0 || movementDirection.z != 0)
        {
            _headBobPosition.y = 0.7f - Mathf.PingPong(Time.time * 0.5f, 0.15f);
        }
        else
        {
            _headBobTimeCounter = 0;
            _headBobPosition.y = Mathf.Lerp(cameraPivot.transform.localPosition.y, 0.7f, Time.deltaTime * 20f);
        }

        cameraPivot.transform.localPosition = _headBobPosition;
    }

    void UpdateRotation()
    {
        Vector3 rotationDirection = new Vector3(0, Camera.main.transform.localRotation.eulerAngles.y, 0);
        transform.localEulerAngles = rotationDirection;
    }
}
