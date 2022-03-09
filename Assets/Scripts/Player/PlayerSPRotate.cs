using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSPRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;
    private Vector3 lookDirection;
    private Vector3 lastSavedLookDirection;
    public Vector3 LookDirection => lastSavedLookDirection;
    private float TurnsmoothVelocity;
    private void Start()
    {
        lastSavedLookDirection = -Vector3.right;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraForward = Vector3.forward;
        Vector3 cameraRight = -Vector3.right;
        lookDirection = ((cameraRight * InputManager.Instance.PlayerInput.Movement.z) + (cameraForward * InputManager.Instance.PlayerInput.Movement.x)).normalized;

        if(lookDirection.sqrMagnitude >= 0.1f)
        {
            // Usually you use transform.LookAt for this.
            // But this can give you more control over the angle
            float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngle, ref TurnsmoothVelocity, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            //"Save the lookdirection
            lastSavedLookDirection = lookDirection;
        }
    }
}
