using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteraction : InteractableBehaviour
{
    [SerializeField] private bool _wasInteracted;
    [SerializeField] private Animator _washAnimator;

    protected override void Awake()
    {
        base.Awake();
    }
    

    public override void Interact()
    {
        if (!_wasInteracted)
        { 
            //Play animation
        }
    }
    
}
