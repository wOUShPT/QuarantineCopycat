using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private PlayerMovement _movement;
    private CameraManager cameraManager;
    private AIShowing showing;
    [SerializeField]private Transform placeCopyCat;
    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        cameraManager = FindObjectOfType<CameraManager>();
        showing = FindObjectOfType<AIShowing>();
    }
    void Update()
    {
        _animator.SetFloat("Velocity", PlayerProperties.FreezeMovement ? 0f : _movement.currentVelocity);
    }
    private void SetPlaceCopycat(Transform _transform)
    {
        placeCopyCat = _transform;
    }
    //Cutscene of Copycat appearing
    public void SeeCopyCat()
    {
        SetPlayerProperties(true);
        cameraManager.ChangeWatchCopycat();
        showing.SetCopyCatPosition(placeCopyCat);
        StartCoroutine(RotateBryan());
    }

    private IEnumerator RotateBryan()
    {
        float elapsed = 0f;
        float totalTime = 2f;
        float MathAngleY = transform.localRotation.eulerAngles.y + 90;
        
        while (elapsed < totalTime)
        {
            float angle = Mathf.LerpAngle(transform.localRotation.eulerAngles.y, MathAngleY, (float)elapsed / totalTime);
            transform.localRotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = Quaternion.Euler(transform.rotation.x, MathAngleY, transform.rotation.z);
        SetPlayerProperties(false);
        cameraManager.ChangeToCinematic();
    }
    private void SetPlayerProperties(bool state)
    {
        PlayerProperties.Mode = state ? PlayerProperties.State.Cutscene : PlayerProperties.State.Dynamic;
        PlayerProperties.FreezeAim = state;
        PlayerProperties.FreezeMovement = state;
        PlayerProperties.FreezeInteraction = state;
    }
}
