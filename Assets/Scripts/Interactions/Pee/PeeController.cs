using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeController : MonoBehaviour
{
    [SerializeField]
    private Transform _peeOriginTransform;

    [SerializeField] private float horizontalSensitivity;
    [SerializeField] private float verticalSensitivity;
    [SerializeField] private Vector2 horizontalClamp;
    [SerializeField] private Vector2 verticalClamp;
    [SerializeField] private float recenterSpeed;
    private Vector3 _currentLocalRotation;
    private Vector3 _startLocalRotation;

    private void Awake()
    {
        _startLocalRotation = _peeOriginTransform.localRotation.eulerAngles;
    }

    private void OnEnable()
    {
        _currentLocalRotation = _startLocalRotation;
        _peeOriginTransform.localRotation = Quaternion.Euler(_currentLocalRotation);
    }

    
    void Update()
    {
        _currentLocalRotation = new Vector3(
            (-InputManager.Instance.PlayerInput.Look.y * verticalSensitivity * Time.deltaTime) + _currentLocalRotation.x,
            (InputManager.Instance.PlayerInput.Look.x * horizontalSensitivity * Time.deltaTime) +
            _currentLocalRotation.y, _currentLocalRotation.z);
        _currentLocalRotation = Vector3.Lerp(_currentLocalRotation, _startLocalRotation, Time.deltaTime * recenterSpeed);
        _currentLocalRotation = new Vector3(Mathf.Clamp(_currentLocalRotation.x, verticalClamp.x, verticalClamp.y),
            Mathf.Clamp(_currentLocalRotation.y, horizontalClamp.x, horizontalClamp.y), _currentLocalRotation.z);
        _peeOriginTransform.localRotation = Quaternion.Euler(_currentLocalRotation);
    }
}
