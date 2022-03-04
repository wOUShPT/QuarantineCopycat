using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushingTeethBehaviour : InteractableBehaviour
{
    [SerializeField] private MeshCollider interactionTriggerCollider;  
    private Animator _toothBrushAnimator;
    // Start is called before the first frame update
    protected void Start()
    {
        interactionTriggerCollider.enabled = false;
    }
    
    //Called by the timeline
    public void BrushTeethAnimationStart() // Play animation
    {
        //toothBrushAnimator.Play("ToothbrushAnimation");
    }
    public void BrushTeethAnimationStop()
    {
        //toothBrushAnimator.Play("NewState");
    }

}
