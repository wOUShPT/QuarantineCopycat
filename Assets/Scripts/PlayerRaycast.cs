using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public Action<RaycastHit> raycastCallback;
    private RaycastHit[] _hitResults;
    private RaycastHit hit;
    [SerializeField]
    private float range;

    private void Awake()
    {
        _hitResults = new RaycastHit[1];
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
        int hits = Physics.RaycastNonAlloc(ray, _hitResults, range);

        if (Physics.Raycast(ray, out hit, range))
        {
            raycastCallback(hit);
        }

        Debug.DrawRay(ray.origin, ray.direction, Color.green);
    }

}
