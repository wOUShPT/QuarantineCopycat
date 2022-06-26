using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class FMODFootstepsEmitter : MonoBehaviour
{
    private EventReference _eventReference;
    private EventReference _lastEventReference;
    private EventInstance _instance;
    [SerializeField] private LayerMask layerMask;
    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        _ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, layerMask) && _hit.collider.TryGetComponent(out FMODFloor fmodFloor))
        {
            _eventReference = fmodFloor.GetEventReference();
            
            if (!_instance.isValid() || _lastEventReference.Path != _eventReference.Path)
            {
                _instance = RuntimeManager.CreateInstance(_eventReference);
                _lastEventReference = _eventReference;
            }
            
        }
    }

    public void PlayEvent()
    {
        if (_eventReference.IsNull)
        {
            return;
        }

        _instance.start();
    }


    public void OnDestroy()
    {
        _instance.stop(STOP_MODE.ALLOWFADEOUT);
        _instance.release();
    }
}
