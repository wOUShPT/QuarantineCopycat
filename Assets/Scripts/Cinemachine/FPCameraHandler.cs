using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG;
using DG.Tweening;
using DG.Tweening.Core;

public class FPCameraHandler : MonoBehaviour
{
    public MouseSettings mouseSenseData;
    public CinemachineVirtualCamera vCam;
    private CinemachinePOV _povComponent;
    
    private void Awake()
    {
        _povComponent = vCam.GetCinemachineComponent<CinemachinePOV>();
        _povComponent.m_HorizontalAxis.m_MaxSpeed = mouseSenseData.mouseSensitivity * 2f;
        _povComponent.m_VerticalAxis.m_MaxSpeed = mouseSenseData.mouseSensitivity * 0.56f * 2f;
    }

    private void Update()
    {
        if (PlayerProperties.FreezeAim)
        {
            return;
        }
        _povComponent.m_HorizontalAxis.m_InputAxisValue = InputManager.Instance.PlayerInput.Look.x;
        _povComponent.m_VerticalAxis.m_InputAxisValue = InputManager.Instance.PlayerInput.Look.y;
    }

    public void RecenterCameraOnYaw(float duration)
    {
        StartCoroutine(RecenterCameraOnYawCoroutine(duration));
    }

    IEnumerator RecenterCameraOnYawCoroutine(float duration)
    {
        _povComponent.m_HorizontalAxis.m_InputAxisValue = 0;
        _povComponent.m_VerticalAxis.m_InputAxisValue = 0;
        _povComponent.m_VerticalRecentering.m_RecenteringTime = duration;
        _povComponent.m_VerticalRecentering.m_enabled = true;
        yield return new WaitForSeconds(duration * 3f);
        //_povComponent.m_VerticalAxis.Value = 0;
        _povComponent.m_VerticalRecentering.m_enabled = false;
    }
}
