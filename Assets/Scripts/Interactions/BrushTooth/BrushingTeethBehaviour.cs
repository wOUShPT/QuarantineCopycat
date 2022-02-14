using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushingTeethBehaviour : ToggleInteractionTrigger
{
    [SerializeField] private MeshCollider interactionTriggerCollider;  
    private Animator toothBrushAnimator;
    // Start is called before the first frame update
    protected override void Start()
    {
        interactionTriggerCollider.enabled = false;
        base.Start();
        
    }

    public override void CheckPlayeerHasToothSpecificItem()
    {
        
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
