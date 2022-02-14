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
            PickUpItemBehaviour pickUpItem = pickupBehaviour.GetInventory().CheckHasItem(PickUpItemBehaviour.PickUpObjectType.Plate);
            if (pickUpItem != null && !pickUpItem.IsPlateWashed)
            {
                //If has the plate not washed yet
                itemBehaviour = pickUpItem;
                PlateIsWashed();
            }
        }
    }
    public void PlateIsWashed()
    {
        itemBehaviour.IsPlateWashed = true;
    }

    

}
