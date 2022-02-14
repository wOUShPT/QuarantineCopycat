using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgePlace : ItemSpotBehaviour
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        dropObjectType = PickUpItemBehaviour.PickUpObjectType.Food;
        base.Awake();
        for (int i = 0; i < fridgeParams.foodTransform.Length; i++) //There is food at the fridge
        {
            if(i >= fridgeParams.foodPickUps.Count)
            {
                break;
            }
            fridgeParams.foodPickUps[i].transform.SetParent(fridgeParams.foodTransform[i]);
            fridgeParams.foodPickUps[i].transform.localPosition = Vector3.zero;
        }
    }

    protected override void CheckPlayerHasItem()
    {
        PickUpItemBehaviour pickUpItem = playerPickUp.GetInventory().CheckHasItem(DropObjectType);
        if (pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Food && !IsFridgeFull())
        {
            item = pickUpItem;
            playerPickUp.BreakConnection(item);
            PlaceItemToSpot();
        }
    }
    private bool IsFridgeFull()
    {
        foreach (Transform fridgeSpot in fridgeParams.foodTransform)
        {
            if(fridgeSpot.childCount == 0)
            {
                return false; // the fridge is not full
            }
        }
        return true; // The Fridge is full
    }
    protected override void PlaceItemToSpot()
    {
        foreach (Transform fridgeSpot in fridgeParams.foodTransform)
        {
            if(fridgeSpot.childCount == 0)
            {
                item.transform.SetParent(fridgeSpot); // see an available spot to put the food
                break;
            }
        }
        SetItemValuesDefault(item.transform);
        item.transform.localScale = item.InitialScale;
    }
}
