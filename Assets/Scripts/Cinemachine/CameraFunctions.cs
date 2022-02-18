using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFunctions : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ResetCameraTransform()
    {
        if (_camera.Follow != null && _camera.LookAt != null)
        {
            Debug.Log("Camere Transform Reset");
            _camera.ForceCameraPosition(_camera.Follow.position, _camera.LookAt.rotation);
        }
    }

    public void SetLookAtObject(Transform _lookatTarget)
    {
        if(_camera.LookAt == null)
        {
            _camera.LookAt = _lookatTarget;
        }
    }
    public void SetNullLookAt()
    {
        if(_camera.LookAt != null)
        {
            _camera.LookAt = null; //Set camera look at as null
        }
    }
}
