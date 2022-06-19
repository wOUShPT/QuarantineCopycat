using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private PlayerMovement _movement;
    private float _footIndex;
    private CameraManager cameraManager;
    private AIShowing showing;
    private float _lookBackTimer;
    private float _lookBackTargetTime;
    [SerializeField]private Vector2 lookBackRandomTimeInterval;
    [SerializeField]private Transform placeCopyCat;
    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        cameraManager = FindObjectOfType<CameraManager>();
        showing = FindObjectOfType<AIShowing>();
        _lookBackTimer = 0;
        _lookBackTargetTime = Random.Range(lookBackRandomTimeInterval.x, lookBackRandomTimeInterval.y);
    }
    void Update()
    {
        _animator.SetFloat("Velocity", PlayerProperties.FreezeMovement ? 0f : _movement.currentVelocity);
        _animator.SetFloat("Horizontal", _movement.CurrentMoveDirection.x);
        _animator.SetFloat("Vertical", _movement.CurrentMoveDirection.z);
        _animator.SetBool("isRunning", PlayerProperties.FreezeMovement ? false : _movement.GetIsSprinting());
        if (_movement.currentVelocity == 0)
        {
            _footIndex = Mathf.Pow(-1, Random.Range(2, 4));
            _animator.SetFloat("Foot", _footIndex);
        }

        if (!_movement.GetIsSprinting())
        {
            _lookBackTimer = 0;
            return;
        }
        
        _lookBackTimer += Time.deltaTime;
        
        if (_lookBackTimer >= _lookBackTargetTime)
        {
            _lookBackTimer = 0;
            _lookBackTargetTime = Random.Range(lookBackRandomTimeInterval.x, lookBackRandomTimeInterval.y);
            _animator.SetTrigger("LookBack");
        }
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
