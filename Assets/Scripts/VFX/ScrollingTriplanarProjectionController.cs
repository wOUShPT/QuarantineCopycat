using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

[ExecuteAlways]
public class ScrollingTriplanarProjectionController : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Color _color;
    [SerializeField] private float _fadeAttenuation;
    [SerializeField] private float _scale;
    [SerializeField] private Vector3 _scaleDirection;
    [SerializeField] private float _power;
    [SerializeField] private float _sphereSize;
    [SerializeField] private Vector3 _sphereOrigin;
    
    public void Update()
    {
        _material.SetColor("_Color", _color);
        _material.SetFloat("_FadeAttenuation", _fadeAttenuation);
        _material.SetFloat("_Scale", _scale);
        _material.SetVector("_ScaleDirection", _scaleDirection);
        _material.SetFloat("_Power", _power);
        _material.SetFloat("_SphereSize", _sphereSize);
        _material.SetVector("_SphereOrigin", _sphereOrigin);
    }
}
