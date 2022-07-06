using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class SimpleTrigger : MonoBehaviour
{
    //[SerializeField] private LayerMask layerMask;
    [SerializeField] private bool triggerOnce;
    [SerializeField] private UnityEvent effect;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            effect.Invoke();
            enabled = !triggerOnce;
        }
    }
}
