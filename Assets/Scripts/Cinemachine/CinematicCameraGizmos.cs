using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CinematicCameraGizmos : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform lookAt;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pivot.position, lookAt.position);
    }
}
