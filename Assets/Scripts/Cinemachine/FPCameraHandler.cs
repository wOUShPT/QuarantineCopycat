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

    public void MoveCameraOnYaw(AnimationCurve animationCurve)
    {
        StartCoroutine(MoveCameraOnYawCurveCoroutine(animationCurve));
    }
    
    public void MoveCameraOnYaw(float duration, float targetValue)
    {
        StartCoroutine(MoveCameraOnYawCoroutine(duration, targetValue));
    }
    
    public void MoveCameraOnPitch(AnimationCurve animationCurve)
    {
        StartCoroutine(MoveCameraOnPitchCurveCoroutine(animationCurve));
    }
    
    public void MoveCameraOnPitch(float duration, float targetValue)
    {
        StartCoroutine(MoveCameraOnPitchCoroutine(duration, targetValue));
    }
    

    IEnumerator MoveCameraOnYawCurveCoroutine(AnimationCurve curve)
    {
        _povComponent.m_HorizontalAxis.m_InputAxisValue = 0;
        _povComponent.m_VerticalAxis.m_InputAxisValue = 0;
        float elapsedTime = 0;
        while (elapsedTime < curve.keys[curve.keys.Length - 1].time)
        {
            elapsedTime += Time.deltaTime;
            _povComponent.m_VerticalAxis.Value = curve.Evaluate(elapsedTime);
            yield return new WaitForEndOfFrame();
        }

        _povComponent.m_VerticalAxis.Value = curve.keys[curve.keys.Length - 1].value;
    }
    
    IEnumerator MoveCameraOnYawCoroutine(float duration, float targetValue)
    {
        _povComponent.m_HorizontalAxis.m_InputAxisValue = 0;
        _povComponent.m_VerticalAxis.m_InputAxisValue = 0;
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            _povComponent.m_VerticalAxis.Value = Mathf.Lerp(_povComponent.m_VerticalAxis.Value, targetValue, elapsedTime/duration);
            yield return new WaitForEndOfFrame();
        }

        _povComponent.m_VerticalAxis.Value = targetValue;
    }
    
    IEnumerator MoveCameraOnPitchCoroutine(float duration, float targetValue)
    {
        _povComponent.m_HorizontalAxis.m_InputAxisValue = 0;
        _povComponent.m_VerticalAxis.m_InputAxisValue = 0;
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            _povComponent.m_HorizontalAxis.Value = Mathf.Lerp(_povComponent.m_HorizontalAxis.Value, targetValue, elapsedTime/duration);
            yield return new WaitForEndOfFrame();
        }

        _povComponent.m_HorizontalAxis.Value = targetValue;
    }
    
    IEnumerator MoveCameraOnPitchCurveCoroutine(AnimationCurve curve)
    {
        _povComponent.m_HorizontalAxis.m_InputAxisValue = 0;
        _povComponent.m_VerticalAxis.m_InputAxisValue = 0;
        float elapsedTime = 0;
        while (elapsedTime < curve.keys[curve.keys.Length - 1].time)
        {
            elapsedTime += Time.deltaTime;
            _povComponent.m_HorizontalAxis.Value = curve.Evaluate(elapsedTime);
            yield return new WaitForEndOfFrame();
        }

        _povComponent.m_HorizontalAxis.Value = curve.keys[curve.keys.Length - 1].value;
    }
}
