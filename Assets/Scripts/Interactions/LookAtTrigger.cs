using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class LookAtTrigger : MonoBehaviour
{
    [SerializeField] private Transform lookAtTransform;
    [SerializeField] private float lookPercentageThreshold;
    [SerializeField] private float minimumTriggerDistance;
    [SerializeField] private float maximumTriggerDistance;
    [SerializeField] private float delayInSeconds;
    [SerializeField] private bool triggerOnce;
    [SerializeField] private UnityEvent effect;
    private Camera _mainCamera;
    private Vector3 _lookAtToCameraDirection;
    private float _lookAtToCameraDistance;
    private float _lookPercentage = 0;
    private bool _onSight = false;

    protected void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {

        _lookAtToCameraDistance = Vector3.Distance(_mainCamera.transform.position, lookAtTransform.position);

        if (_lookAtToCameraDistance < minimumTriggerDistance || _lookAtToCameraDistance > maximumTriggerDistance)
        {
            return;
        }

        _lookPercentage = Vector3.Dot(_lookAtToCameraDirection, -_mainCamera.transform.forward);

        //Debug.Log("Trigger Distance: "+ _lookAtToCameraDistance + " / Look Percentage: " + _lookPercentage);

        if (_lookPercentage >= lookPercentageThreshold / 100f && _onSight)
        {
            effect.Invoke();
            enabled = !triggerOnce;
        }

    }

    private void FixedUpdate()
    {
        _lookAtToCameraDirection = _mainCamera.transform.position + Vector3.down * 0.25f - lookAtTransform.position;

        if (Physics.Raycast(lookAtTransform.position,  _lookAtToCameraDirection, out RaycastHit hit, _lookAtToCameraDistance) && hit.collider.TryGetComponent(out CharacterController controller))
        {
            _onSight = true;
            return;
        }
        
        _onSight = false;

        Debug.DrawRay(lookAtTransform.position, _lookAtToCameraDirection * _lookAtToCameraDistance, Color.magenta);
    }
}
