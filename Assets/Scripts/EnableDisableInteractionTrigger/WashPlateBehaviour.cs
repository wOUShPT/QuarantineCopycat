using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashPlateBehaviour : ToggleInteractionTrigger
{
    [SerializeField] private CapsuleCollider interactionTriggerCollider;
    protected PickUpItemBehaviour itemBehaviour;
    protected override void Start()
    {
        interactionTriggerCollider = GetComponent<CapsuleCollider>();
        interactionTriggerCollider.enabled = false;
        base.Start();
    }
    public override void CheckPlayeerHasToothSpecificItem()
    {
        if (pickupBehaviour != null)
        {
            if (pickupBehaviour.CurrentlyPickedUpObject != null)
            {
                PickUpItemBehaviour pickUpItem = pickupBehaviour.CurrentlyPickedUpObject;
                if (pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Plate && !pickUpItem.IsPlateWashed)
                {
                    //If has the plate not washed yet
                    AssignAndMakeInteractionTriggerInteraction(pickUpItem);
                }
            }
        }
    }

    public override void CheckPlayerDropSpecificItem()
    {
        if (pickupBehaviour != null)
        {
            if (pickupBehaviour.CurrentlyPickedUpObject == null && ItemToInteractionTriggerPivot != null)
            {
                MakeTriggerInteractionDisabled();
            }
        }
    }

    protected override void AssignAndMakeInteractionTriggerInteraction(PickUpItemBehaviour pickUpItem)
    {
        itemBehaviour = pickUpItem;
        ItemToInteractionTriggerPivot = itemBehaviour.transform;
        interactionTriggerCollider.enabled = true; // now the interaction trigger can be interactable
    }

    protected override void MakeTriggerInteractionDisabled()
    {
        itemBehaviour = null;
        ItemToInteractionTriggerPivot = null;
        interactionTriggerCollider.enabled = false; // now the interaction trigger can be interactable
    }
    public void PlateIsWashed()
    {
        itemBehaviour.IsPlateWashed = true;
    }

    

}
