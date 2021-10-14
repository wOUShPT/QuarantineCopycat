using System;
using System.Collections;
using System.Collections.Generic;
using KevinCastejon.EditorToolbox;
using UnityEngine;

public class DartCollision : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField, Tag]
    private string dartBoardTag;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag(dartBoardTag))
        {
            _rb.constraints = RigidbodyConstraints.FreezeAll;
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.angularDrag = 0;
            _rb.useGravity = false;
        }
    }
    
    private void OnEnable()
    {
        _rb.constraints = RigidbodyConstraints.None;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.angularDrag = 0;
        _rb.useGravity = true;
    }
}
