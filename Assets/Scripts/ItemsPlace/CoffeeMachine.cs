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
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.enabled = false;
        item.gameObject.SetActive(true);
    }

    protected override void TakeItemToPlayer()
    {
        if (coffeeMachineParams.IsCoffeeBeDoing)
            return;
        if (playerPickUp.CurrentlyPickedUpObject != null) // it's a book player has picked
            return; //player has picked up something
        // Player took the coffee
        playerPickUp.GetPickedupObject(item);
        item = null;
        interactDelegate = CheckPlayerHasItem;
    }
    IEnumerator WaitToMakeToastWork()
    {
        coffeeMachineParams.BoxCollider.enabled = false;
        yield return new WaitForSeconds(.6f); //Avoid interact immediatly with the toast
        coffeeMachineParams.InteractionTriggerCollider.enabled = true;
    }
    public void CoffeIsReady()
    {
        item.ItemCollider.enabled = true;
        item.CoffeeInteractionTrigger.enabled = true;
        item.enabled = false;
        Destroy(item);
    }
}
