using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothPlace : ItemSpotBehaviour
{
    [SerializeField] protected int maxNumberCloths = 3;
    protected override void Awake()
    {
        clothParamsStack = new Stack<ClothParams>();
        base.Awake();
        dropObjectType = PickUpItemBehaviour.PickUpObjectType.Cloth;
    }

    protected override void CheckPlayerHasItem()
    {
        if (CheckLaundryHasCloths())
        {
            TakeItemToPlayer();
            return;
        }
        PickUpItemBehaviour clothBehaviour = playerPickUp.GetInventory().CheckHasItem(DropObjectType);
        if (clothParamsStack.Count >= maxNumberCloths)
        {
            return;
        }
        if (clothBehaviour == null)
        {
            return; //can't put an cloth on a book spot
        }
        item = clothBehaviour;
        clothBehaviour.PickedUp = false;
        playerPickUp.BreakConnection(item); // Drop book
        PlaceItemToSpot();
    }
    private bool CheckLaundryHasCloths() //Check the laundry has cloths
    {
        if (clothParamsStack.Count > 0)
        {
            return true; // has at least one cloth
        }
        return false; // no cloths
    }

    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(holderPositionArray[clothParamsStack.Count]);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.Euler(Vector3.zero);
        item.transform.localScale = item.InitialScale;
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.isTrigger = true;
        clothParamsStack.Push(new ClothParams(holderPositionArray[clothParamsStack.Count], item));
        item = null;
    }

    protected override void TakeItemToPlayer()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null) // it's a book player has picked
        {
            CheckPlayerHasItem();
        }
        else // Player took cloth
        {
            ClothParams clothParams = clothParamsStack.Pop();
            clothParams.itemBehaviour.ItemCollider.isTrigger = false;
            clothParams.itemBehaviour.ItemRigidbody.isKinematic = true;
            playerPickUp.GetPickedupObject(clothParams.itemBehaviour);
        }
    }
}
