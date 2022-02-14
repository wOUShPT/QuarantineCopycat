using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskPlace : ItemSpotBehaviour
{
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
            item.gameObject.SetActive(true);
            playerPickUp.BreakConnection(item);
            PlaceItemToSpot();
            diskParams.targetMusic = pickUpItem.AudioClip;
            diskParams.diskBehaviour.PlayVinylDisk(diskParams.targetMusic);
            PlayRotateDisk();
        }
    }

    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(childrenItemSpot.Length != 0 ? GetAvailableSpot() : this.transform);
        SetItemValuesDefault(item.transform);
        item.transform.localScale = item.InitialScale;
        // Attach item to this itemspotbehaviour
        item.ItemSpotBehaviour = this;
    }
    public override void ItemGoesToInventory()
    {
        StopRotateDisk();
        //Stop disk vinyl music
        diskParams.diskBehaviour.StopVinylDisk();
        diskParams.targetMusic = null;
        base.ItemGoesToInventory();
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
