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
            itemList = new List<PickUpItemBehaviour>();
        }
    }
    protected override void CheckPlayerHasItem()
    {
        // it's something on the inventory
        PickUpItemBehaviour pickUpItem = playerPickUp.GetInventory().CheckHasItem(DropObjectType);
        if (pickUpItem == null)
        {
            return; 
        }
        item = pickUpItem;
        playerPickUp.BreakConnection(item); // Drop book
        PlaceItemToSpot();
    }

    public override void ItemGoesToInventory()
    {
        GetIem(ref item);
        base.ItemGoesToInventory();
    }
    private void GetIem(ref PickUpItemBehaviour item)
    {
        PickUpItemBehaviour itemSpot = itemList[0];
        itemList.RemoveAt(0);
        item = itemSpot;
    }
    protected override void PlaceItemToSpot()
    {
        item.gameObject.SetActive(true);
        item.transform.SetParent(CheckHasItemChildrenSpot() ? GetAvailableSpot() : this.transform);
        SetItemValuesDefault(item);
        item.transform.localScale = item.InitialScale;
        item.transform.localPosition = Vector3.zero;
        item.ItemCollider.isTrigger = true;
        // Attach item to this itemspotbehaviour
        item.ItemSpotBehaviour = this;
        if (CheckHasItemChildrenSpot())
        {
            itemList.Add(item); //Save item on the stack
            item = null;
        }
    }
}
