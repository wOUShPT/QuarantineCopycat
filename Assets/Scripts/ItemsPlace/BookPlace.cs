using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPlace : ItemSpotBehaviour
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        if(CheckHasItemChildrenSpot())
        {
            //it's not empty
            itemStack = new Stack<PickUpItemBehaviour>();
        }
    }
    //protected override void Start()
    //{
    //    if (CheckHasItemSpotBeginning())
    //    {
    //        PlaceItemToSpot();
    //    }
    //}
    protected override void CheckPlayerHasItem()
    {
        if (playerPickUp.CurrentlyPickedUpObject == null && !AreSpotsFull())
        {
            TakeItemToPlayer();
            return;
        }
        // it's a book player has picked
        PickUpItemBehaviour pickUpItem = playerPickUp.CurrentlyPickedUpObject;
        if ((pickUpItem.ObjectType != DropObjectType && DropObjectType != PickUpItemBehaviour.PickUpObjectType.Any) || AreSpotsFull())
        {
            return; //can't put an cloth on a book spot
        }
        item = pickUpItem;
        item.PickedUp = false;
        playerPickUp.BreakConnection(); // Drop book
        PlaceItemToSpot();
    }

    protected override void TakeItemToPlayer()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null) 
        {
            //player has picked up something previously and didn't drop it until now...
            return;
        }
        if(item == null)
        {
            if(childrenItemSpot.Length == 0 || itemStack.Count == 0)
            {
                return;
            }
            GetIem(ref item);
        }
        // Player took the book or anything
        playerPickUp.GetPickedupObject(item);
        item = null;
    }
    private void GetIem(ref PickUpItemBehaviour item)
    {
        PickUpItemBehaviour itemSpot = itemStack.Pop();
        item = itemSpot;
    }
    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(CheckHasItemChildrenSpot() ? GetAvailableSpot() : this.transform);
        SetItemValuesDefault(item);
        item.transform.localScale = item.InitialScale;
        item.transform.localPosition = Vector3.zero;
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.isTrigger = true;
        if (item.ItemCollider.enabled)
        {
            item.ItemCollider.enabled = false;
        }
        // Attach item to this itemspotbehaviour
        item.ItemSpotBehaviour = this;
        if (CheckHasItemChildrenSpot())
        {
            itemStack.Push(item); //Save item on the stack
            item = null;
        }
    }

}
