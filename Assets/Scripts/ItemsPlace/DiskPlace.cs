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
        PickUpItemBehaviour pickUpItem = playerPickUp.GetInventory().CheckHasItem(DropObjectType);
        if (pickUpItem != null)
        {
            //Player has a disk in his hands
            item = pickUpItem;
            item.PickedUp = false;
            playerPickUp.BreakConnection(item);
            PlaceItemToSpot();
            diskParams.targetMusic = pickUpItem.AudioClip;
            diskParams.diskBehaviour.PlayVinylDisk(diskParams.targetMusic);
            PlayRotateDisk();
            interactDelegate = TakeItemToPlayer;
        }
    }

    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(childrenItemSpot.Length != 0 ? GetAvailableSpot() : this.transform);
        SetItemValuesDefault(item.transform);
        item.transform.localScale = item.InitialScale;
        item.ItemRigidbody.isKinematic = true;
        // Attach item to this itemspotbehaviour
        item.ItemSpotBehaviour = this;
    }

    protected override void TakeItemToPlayer()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null) // it's a disk player has picked
        {
            //has something
            return;
        }
        // Player took the disk or any
        StopRotateDisk();
        playerPickUp.GetPickedupObject(item);
        item = null;
        //Stop disk vinyl music
        diskParams.diskBehaviour.StopVinylDisk();
        diskParams.targetMusic = null;
        interactDelegate = CheckPlayerHasItem;
    }

    public void PlayRotateDisk()
    {
        if(item.ItemAnimator != null)
        {
            item.ItemAnimator.Play("RotateDisk"); //Rotate disk by animator
        }
    }
    public void StopRotateDisk()
    {
        if(item.ItemAnimator != null)
        {
            item.ItemAnimator.Play("Empty"); //Stop disk rotating by animator
        }
    }

}
