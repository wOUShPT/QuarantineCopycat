using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class CinemachineFPCutsceneExtension : CinemachineExtension
{
    private Vector3 _currentRotation;

    private CinemachineFPExtension _cinemachineFpExtension;

    protected override void Awake()
    {
        _cinemachineFpExtension = FindObjectOfType<CinemachineFPExtension>();
    }
    
    public Vector3 CurrentRotation
    {
        get => _currentRotation;
        set
        {
            if (PlayerProperties.Mode == PlayerProperties.State.Dynamic)
            {
                _currentRotation = value;  
            }
        } 
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vCameraBase, CinemachineCore.Stage stage,
        ref CameraState state, float deltaTime)
    {

        if (stage == CinemachineCore.Stage.Aim && PlayerProperties.Mode == PlayerProperties.State.Cutscene)
        {
            _currentRotation = Quaternion.LookRotation((vCameraBase.LookAt.position - vCameraBase.Follow.position).normalized)
                .eulerAngles;

            state.RawOrientation = Quaternion.Euler(_currentRotation.x, _currentRotation.y,
                vCameraBase.LookAt.rotation.eulerAngles.z);
        }
        else
        {
            if (_cinemachineFpExtension != null)
            {
                _currentRotation = _cinemachineFpExtension.CurrentRotation;
            }
        }
    }
}
