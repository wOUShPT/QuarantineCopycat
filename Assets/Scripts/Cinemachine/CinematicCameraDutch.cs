using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.TestTools;

[ExecuteAlways]
public class CinematicCameraDutch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;
    [Range(-180f, 180f), SerializeField] private float dutch;
    
    private void Update()
    {
        vCam.m_Lens.Dutch = dutch;
    }
}
