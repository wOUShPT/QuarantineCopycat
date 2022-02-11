using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : ItemSpotBehaviour
{
    
    protected override void Awake()
    {
        coffeeMachineParams.BoxCollider = GetComponent<BoxCollider>();
        coffeeMachineParams.InteractionTriggerCollider.enabled = false;
        coffeeMachineParams.BoxCollider.enabled = true;
        base.Awake();
    }

    protected override void CheckPlayerHasItem()
    {
        PickUpItemBehaviour pickUpItem = playerPickUp.GetInventory().CheckHasItem(DropObjectType);
        if (pickUpItem != null)
        {
            item = pickUpItem;
            item.PickedUp = false;
            playerPickUp.BreakConnection(item); //Player will drop
            PlaceItemToSpot();
            //It's doing imediatly maybe needs a courotine
            StartCoroutine(WaitToMakeToastWork());
        }
    }

    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(coffeeMachineParams.CoffeePivot);
        SetItemValuesDefault(item.transform);
        item.ItemCollider.enabled = false;
        item.gameObject.SetActive(true);
    }
    IEnumerator WaitToMakeToastWork()
    {
        coffeeMachineParams.BoxCollider.enabled = false;
        yield return new WaitForSeconds(.6f); //Avoid interact immediatly with the toast
        coffeeMachineParams.InteractionTriggerCollider.enabled = true;
    }
    //Called by the timeline
    public void CoffeIsReady()
    {
        item.ItemCollider.enabled = true;
        item.CoffeeInteractionTrigger.enabled = true;
        item.enabled = false;
        Destroy(item);
    }
    public void PlaceCaffeAfterDrink(Transform coffeTransform)
    {
        coffeTransform.position = coffeeMachineParams.afterDrinkCoffeeTransform.position;
    }
}
