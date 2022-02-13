using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FPCameraHandler : MonoBehaviour
{
    public MouseSettings mouseSenseData;
    public CinemachineVirtualCamera vCam;
    private CinemachinePOV _povComponent;
    
    private void Awake()
    {
        _povComponent = vCam.GetCinemachineComponent<CinemachinePOV>();
        _povComponent.m_HorizontalAxis.m_MaxSpeed = mouseSenseData.mouseSensitivity * 5f;
        _povComponent.m_VerticalAxis.m_MaxSpeed = mouseSenseData.mouseSensitivity * 0.56f * 5f;
    }

    private void Update()
    {
        _povComponent.m_HorizontalAxis.m_InputAxisValue = InputManager.Instance.PlayerInput.Look.x;
        _povComponent.m_VerticalAxis.m_InputAxisValue = InputManager.Instance.PlayerInput.Look.y;
    }
}
