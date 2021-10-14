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
    
    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
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
    }

    void UpdateRotation()
    {
        Vector3 rotationDirection = new Vector3(0, Camera.main.transform.localRotation.eulerAngles.y, 0);
        transform.localEulerAngles = rotationDirection;
    }
}
