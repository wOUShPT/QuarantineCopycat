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
                WaterCanPlay();
            }
        }
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
