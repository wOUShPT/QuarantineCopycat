using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BlindBehaviour : InteractableBehaviour
{
    private bool isClosed;
    private bool wasInteracted;

    private Animator _animator;
    //Layer
    //delegate
    private delegate void BlindAction();
    private BlindAction blindAction;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    public void Start()
    {
        isClosed = true;
        wasInteracted = false;
    }

    public override void Interact()
    {
        if (CheckWasInteracted())
            return;
        if (isClosed)
        {
            blindAction = ( OpenBlind);
        }
        else
        {
            blindAction = CloseBlind;
        }
        blindAction?.Invoke();
        wasInteracted = true;
    }
    private bool CheckWasInteracted()
    {
        if(wasInteracted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OpenBlind()
    {
        _animator.Play("StackOpen");
        isClosed = false;
    }
    private void CloseBlind()
    {
        _animator.Play("StackClose");
        isClosed = true;
    }
}
