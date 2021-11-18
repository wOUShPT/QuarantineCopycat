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
        for (int i = 0; i < fridgeParams.foodTransform.Length; i++)
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
        if( playerPickUp.CurrentlyPickedUpObject == null && !IsFridgeEmpty()) // Player doesn't have an item
        {
            TakeItemToPlayer();
            return;
        }
        //Has an item
        PickUpItemBehaviour pickUpItem = playerPickUp.CurrentlyPickedUpObject;
        if (pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Food && !IsFridgeFull())
        {
            item = pickUpItem;
            item.PickedUp = false;
            fridgeParams.foodPickUps.Add(item);
            playerPickUp.BreakConnection();
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
    private bool IsFridgeEmpty()
    {
        foreach (Transform fridgeSpot in fridgeParams.foodTransform)
        {
            if (fridgeSpot != null)
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
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.enabled = false;
    }

    protected override void TakeItemToPlayer()
    {
        TakeSpecificFoodInTheFridge();
        // Player took the fridge
        playerPickUp.GetPickedupObject(item);
        item = null;
        interactDelegate = CheckPlayerHasItem;
    }
    private void TakeSpecificFoodInTheFridge()
    {
        foreach (Transform fridgeSpot in fridgeParams.foodTransform) // See the available spot
        {
            if (fridgeSpot.childCount == 0)
            {
                return;
            }
            item = fridgeSpot.GetComponentInChildren<PickUpItemBehaviour>();
            break;
        }
        foreach( PickUpItemBehaviour foodPickUp in fridgeParams.foodPickUps)
        {
            if( item == foodPickUp)
            {
                fridgeParams.foodPickUps.Remove(item);
                break;
            }
        }
    }
}
