using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public Action<RaycastHit> raycastCallback;
    private RaycastHit hit;
    [SerializeField]
    private float range;
    private Camera _camera;
    private Ray ray;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, range))
        {
            raycastCallback(hit);
        }

        Debug.DrawRay(ray.origin, ray.direction, Color.green);
    }

}
