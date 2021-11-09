using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _mirrorCameraPivot;
    private Transform _mainCameraTransform;

    void Awake()
    {
        if (_mainCameraTransform == null)
        {
            _mainCameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        Vector3 lookDir = Camera.main.transform.position - _mirrorCameraPivot.position;
        lookDir.Normalize();
        Quaternion lookRotation = Quaternion.LookRotation(lookDir);
        lookRotation.eulerAngles = _mirrorCameraPivot.eulerAngles + lookRotation.eulerAngles;
        lookRotation.eulerAngles = new Vector3(0, lookRotation.eulerAngles.y, lookRotation.eulerAngles.z);
        transform.localRotation = lookRotation;
    }
}
