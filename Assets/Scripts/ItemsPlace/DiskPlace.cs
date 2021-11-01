using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskPlace : ItemSpotBehaviour
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        dropObjectType = PickUpItemBehaviour.PickUpObjectType.Disk;//Force to disk
        base.Awake();
        if (diskParams.diskBehaviour == null)
        {
            diskParams.diskBehaviour = GetComponent<VinylDiskBehaviour>();
        }
    }

    protected override void CheckPlayerHasItem()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null)
        {
            PickUpItemBehaviour pickUpItem = playerPickUp.CurrentlyPickedUpObject;
            if (pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Disk)
            {
                item = pickUpItem;
                item.PickedUp = false;
                playerPickUp.BreakConnection();
                PlaceItemToSpot();
                diskParams.targetMusic = pickUpItem.AudioClip;
                diskParams.diskBehaviour.PlayVinylDisk(diskParams.targetMusic);
                interactDelegate = TakeItemToPlayer;
            }
        }
    }

    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(childrenItemSpot != null ? childrenItemSpot : this.transform);
        SetItemValuesDefault(item.transform);
        item.transform.localScale = item.InitialScale;
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.isTrigger = true;
    }

    protected override void TakeItemToPlayer()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null) // it's a book player has picked
        {
            //has something
            return;
        }
        // Player took the book or any
        playerPickUp.GetPickedupObject(item);
        item = null;
        //Stop disk vinyl music
        diskParams.diskBehaviour.StopVinylDisk();
        diskParams.targetMusic = null;
        interactDelegate = CheckPlayerHasItem;
    }

}
