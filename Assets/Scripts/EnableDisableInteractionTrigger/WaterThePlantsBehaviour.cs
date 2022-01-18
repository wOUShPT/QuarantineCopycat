using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterThePlantsBehaviour : ToggleInteractionTrigger
{

    [SerializeField] private CapsuleCollider interactionTriggerCollider;
    private ParticleSystem wateringcanParticleSystem;
    // Start is called before the first frame update
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
            PickUpItemBehaviour pickUpItem = pickupBehaviour.GetInventory().CheckHasItem(PickUpItemBehaviour.PickUpObjectType.WateringCan);
            if (pickUpItem != null)
            {
                //If has toothBrushPivot
                AssignAndMakeInteractionTriggerInteraction(pickUpItem);
            }
        }
    }

    public override void CheckPlayerDropSpecificItem()
    {
        if (pickupBehaviour != null)
        {
            if (ItemToInteractionTriggerPivot != null)
            {
                MakeTriggerInteractionDisabled();
            }
        }
    }

    protected override void AssignAndMakeInteractionTriggerInteraction(PickUpItemBehaviour pickUpItem)
    {
        ItemToInteractionTriggerPivot = pickUpItem.transform;
        wateringcanParticleSystem = pickUpItem.GetWaterParticle;
        interactionTriggerCollider.enabled = true; // now the interaction trigger can be interactable
    }

    protected override void MakeTriggerInteractionDisabled()
    {
        ItemToInteractionTriggerPivot = null;
        wateringcanParticleSystem = null;
        interactionTriggerCollider.enabled = false; // now the interaction trigger can be interactable
    }
    //Called by the timeline
    public void WaterCanPlay()
    {
        wateringcanParticleSystem.Play();
    }
    public void WaterCanStop()
    {
        wateringcanParticleSystem.Stop();
    }
}
