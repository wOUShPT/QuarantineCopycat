using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FMODFloor : MonoBehaviour
{
    private CameraManager _cameraManager;
    [SerializeField] private EventReference floorEventReference;
    [SerializeField] private EventReference floorEventReference3D;
    private EventReference _currentReference;

    private void Awake()
    {
        _currentReference = floorEventReference;
    }

    public void Update()
    {
        if (CameraManager.CinemachineCameraState == CameraManager.CinemachineStateSwitcher.SecondPerson)
        {
            _currentReference = floorEventReference3D;
            return;
        }

        _currentReference = floorEventReference;
    }

    public EventReference GetEventReference()
    {
        return _currentReference;
    }
}
