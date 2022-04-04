using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : InteractableBehaviour
{
    [SerializeField] private UnityEvent effect;

    public override void Interact()
    {
        if (CanInteract)
        {
            effect.Invoke();
        }
    }
}
