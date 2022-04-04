using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

[ExecuteAlways]
public class ScrollingTriplanarProjectionController : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private float _scale;
    [SerializeField] private float _power;
    [SerializeField] private float _sphereSize;
    [SerializeField] private Vector4 _sphereOrigin;
    
    public void Update()
    {
        _material.SetFloat("_Scale", _scale);
        _material.SetFloat("_Power", _power);
        _material.SetFloat("_SphereSize", _sphereSize);
        _material.SetVector("_SphereOrigin", _sphereOrigin);
    }
}
