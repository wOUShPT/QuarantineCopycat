using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterMachine : ItemSpotBehaviour
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        breadParams.BoxCollider = GetComponent<BoxCollider>();
        breadParams.InteractionTriggerCollider.enabled = false;
        breadParams.BoxCollider.enabled = true;
        base.Awake();
    }

    protected override void CheckPlayerHasItem()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null)
        {
            PickUpItemBehaviour pickUpItem = playerPickUp.CurrentlyPickedUpObject;
            if (pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Bread)
            {
                item = pickUpItem;
                item.PickedUp = false;
                playerPickUp.BreakConnection();
                PlaceItemToSpot();
                //It's doing imediatly maybe needs a courotine
                StartCoroutine(WaitToMakeToastWork());
                interactDelegate = TakeItemToPlayer;
            }
        }
    }

    protected override void PlaceItemToSpot()
    {
        breadParams.LeftToast = item.LeftToast;
        breadParams.LeftToast.SetParent(breadParams.LeftToasterPivot);
        SetItemValuesDefault(breadParams.LeftToast);
        breadParams.RightToast = item.RightToast;
        breadParams.RightToast.SetParent(breadParams.RightToasterPivot);
        SetItemValuesDefault(breadParams.RightToast);
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.isTrigger = true;
    }

    protected override void TakeItemToPlayer()
    {
        if (breadParams.IsBreadDoing)
            return;
        if (playerPickUp.CurrentlyPickedUpObject != null) // it's a book player has picked
        {
            return; //player has picked up something
        }
        // Player took the book or any
        breadParams.LeftToast.SetParent(item.transform);
        SetItemValuesDefault(breadParams.LeftToast);
        breadParams.LeftToast = null;
        breadParams.RightToast.SetParent(item.transform);
        SetItemValuesDefault(breadParams.RightToast);
        breadParams.RightToast = null;
        playerPickUp.GetPickedupObject(item);
        item = null;
        interactDelegate = CheckPlayerHasItem;
    }
    IEnumerator WaitToMakeToastWork()
    {
        breadParams.BoxCollider.enabled = false;
        yield return new WaitForSeconds(.6f); //Avoid interact immediatly with the toast
        breadParams.InteractionTriggerCollider.enabled = true;
    }
}
