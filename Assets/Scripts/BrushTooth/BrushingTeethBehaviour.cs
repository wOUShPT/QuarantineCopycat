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
        if(pickupBehaviour != null)
        {
            if(pickupBehaviour.CurrentlyPickedUpObject != null)
            {
                PickUpItemBehaviour pickUpItem = pickupBehaviour.CurrentlyPickedUpObject;
                if( pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Toothbrush)
                {
                    //If has toothBrushPivot
                    AssignAndMakeInteractionTriggerInteraction(pickUpItem);
                }
            }
        }
    }
    protected override void AssignAndMakeInteractionTriggerInteraction(PickUpItemBehaviour pickUpItem)
    {
        ItemToInteractionTriggerPivot = pickUpItem.transform;
        toothBrushAnimator = pickUpItem.ItemAnimator;
        interactionTriggerCollider.enabled = true; // now the interaction trigger can be interactable
    }
    public override void CheckPlayerDropSpecificItem()
    {
        if( pickupBehaviour != null)
        {
            if( pickupBehaviour.CurrentlyPickedUpObject == null && ItemToInteractionTriggerPivot != null)
            {
                MakeTriggerInteractionDisabled();
            }
        }
    }
    protected override void MakeTriggerInteractionDisabled()
    {
        ItemToInteractionTriggerPivot = null; // make toothbrush references null since player don't have it anymore
        toothBrushAnimator = null;
        interactionTriggerCollider.enabled = false; //now interaction trigger is disabled
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
