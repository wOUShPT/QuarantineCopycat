using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPlace : ItemSpotBehaviour
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        if (transform.childCount > 0)
        {
            childrenItemSpot = this.transform.GetChild(0);
        }
    }

    protected override void CheckPlayerHasItem()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            if (bookBehaviour.ObjectType != DropObjectType && DropObjectType != PickUpItemBehaviour.PickUpObjectType.Any)
            {
                return; //can't put an cloth on a book spot
            }
            item = bookBehaviour;
            item.PickedUp = false;
            playerPickUp.BreakConnection(); // Drop book
            PlaceItemToSpot();
            interactDelegate = TakeItemToPlayer;
        }
    }

    protected override void TakeItemToPlayer()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            //has something
            return;
        }
        // Player took the book or any
        playerPickUp.GetPickedupObject(item.gameObject);
        item = null;
        interactDelegate = CheckPlayerHasItem;
    }
    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(childrenItemSpot != null ? childrenItemSpot : this.transform);
        SetItemValuesDefault(item.transform);
        item.transform.localScale = item.InitialScale;
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.isTrigger = true;
    }

}
