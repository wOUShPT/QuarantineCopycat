using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothPlace : ItemSpotBehaviour
{
    protected override void Awake()
    {
        clothParamsStack = new Stack<ClothParams>();
        base.Awake();
    }

    protected override void CheckPlayerHasItem()
    {
        if (playerPickUp.CurrentlyPickedUpObject == null)
        {
            if (CheckLaundryHasCloths())
            {
                TakeItemToPlayer();
            }
            return;
        }
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour clothBehaviour)) // it's a book player has picked
        {
            if (clothParamsStack.Count >= maxNumberCloths)
            {
                return;
            }
            if (clothBehaviour.ObjectType != DropObjectType && DropObjectType != PickUpItemBehaviour.PickUpObjectType.Any)
            {
                return; //can't put an cloth on a book spot
            }
            item = clothBehaviour;
            clothBehaviour.PickedUp = false;
            playerPickUp.BreakConnection(); // Drop book
            PlaceItemToSpot();
        }
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
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour pickUpItemBehaviour)) // it's a book player has picked
        {
            CheckPlayerHasItem();
        }
        else // Player took cloth
        {
            ClothParams clothParams = clothParamsStack.Pop();
            clothParams.itemBehaviour.ItemCollider.isTrigger = false;
            clothParams.itemBehaviour.ItemRigidbody.isKinematic = true;
            playerPickUp.GetPickedupObject(clothParams.itemBehaviour.gameObject);
        }
    }
}
