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

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        cameraManager = FindObjectOfType<CameraManager>();
    }
    private void Start()
    {
        //SeeCopyCat();
    }

    void Update()
    {
        _animator.SetFloat("Velocity", _movement.currentVelocity);
    }
    public void SeeCopyCat()
    {
        PlayerProperties.Mode = PlayerProperties.State.Cutscene;
        PlayerProperties.FreezeAim = true;
        PlayerProperties.FreezeMovement = true;
        PlayerProperties.FreezeInteraction = true;
        cameraManager.ChangeWatchCopycat();
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
        PlayerProperties.FreezeAim = false;
        PlayerProperties.FreezeMovement = false;
        PlayerProperties.FreezeInteraction = false;
        PlayerProperties.Mode = PlayerProperties.State.Dynamic;
        cameraManager.ChangeToCinematic();
    }
}
