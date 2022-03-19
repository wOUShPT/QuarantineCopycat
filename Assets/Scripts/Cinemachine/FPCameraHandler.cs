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
        _povComponent.m_HorizontalAxis.m_MaxSpeed = mouseSenseData.mouseSensitivity;
        _povComponent.m_VerticalAxis.m_MaxSpeed = mouseSenseData.mouseSensitivity * 0.56f;
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

    public void RecenterCameraOnYaw(float duration, float targetValue)
    {
        StartCoroutine(RecenterCameraOnYawCoroutine(duration, targetValue));
    }

    IEnumerator RecenterCameraOnYawCoroutine(float duration, float targetValue)
    {
        _povComponent.m_HorizontalAxis.m_InputAxisValue = 0;
        _povComponent.m_VerticalAxis.m_InputAxisValue = 0;
        float interval = Mathf.Abs(_povComponent.m_VerticalAxis.Value - targetValue);
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            _povComponent.m_VerticalAxis.Value = Mathf.Lerp(_povComponent.m_VerticalAxis.Value, targetValue, elapsedTime / duration);
            yield return new WaitForEndOfFrame();
        }

        _povComponent.m_VerticalAxis.Value = targetValue;
        Debug.Log("Recentered");
    }
}
