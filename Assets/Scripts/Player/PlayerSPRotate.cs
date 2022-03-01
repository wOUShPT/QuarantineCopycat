using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSPRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;
    private Vector3 movementDirection;
    private Camera playerCamera;
    private float TurnsmoothVelocity;
    private void Awake()
    {
        playerCamera = Camera.main;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        movementDirection = ((cameraForward * InputManager.Instance.PlayerInput.Movement.z) + (cameraRight * InputManager.Instance.PlayerInput.Movement.x)).normalized;

        if(movementDirection.sqrMagnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngle, ref TurnsmoothVelocity, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
    }
}
