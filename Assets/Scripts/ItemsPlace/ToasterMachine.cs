using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterMachine : ItemSpotBehaviour
{
    
    protected override void Awake()
    {
        breadParams.BoxCollider = GetComponent<BoxCollider>();
        breadParams.InteractionTriggerCollider.enabled = false;
        breadParams.BoxCollider.enabled = true;
        base.Awake();
    }

    protected override void CheckPlayerHasItem()
    {
        PickUpItemBehaviour pickUpItem = playerPickUp.GetInventory().CheckHasItem(DropObjectType);
        if (pickUpItem != null)
        {
            item = pickUpItem;
            item.PickedUp = false;
            playerPickUp.BreakConnection(item);
            PlaceItemToSpot();
            //It's doing imediatly maybe needs a courotine
            StartCoroutine(WaitToMakeToastWork());
        }
    }

    protected override void PlaceItemToSpot()
    {
        //Place to bread "parents" as well
        item.transform.position = breadParams.RightToasterPivot.position;
        item.transform.SetParent(breadParams.LeftToasterPivot);
        SetItemValuesDefault(item.transform);
        breadParams.LeftToast = item.LeftToast;
        breadParams.LeftToast.SetParent(breadParams.LeftToasterPivot);
        SetItemValuesDefault(breadParams.LeftToast);
        breadParams.RightToast = item.RightToast;
        breadParams.RightToast.SetParent(breadParams.RightToasterPivot);
        SetItemValuesDefault(breadParams.RightToast);
    }
    public override void ItemGoesToInventory()
    {
        // Player took the book or any
        BreadsReturnPreviousParent();
        base.ItemGoesToInventory();
    }
    public void BreadsReturnPreviousParent() //Make both breads return to the previous parent
    {
        breadParams.LeftToast.SetParent(item.LeftBreadPivot.transform);
        breadParams.RightToast.SetParent(item.RightBreadPivot.transform);
        SetItemValuesDefault(breadParams.LeftToast);
        SetItemValuesDefault(breadParams.RightToast);
    }
    IEnumerator WaitToMakeToastWork()
    {
        breadParams.BoxCollider.enabled = false;
        yield return new WaitForSeconds(.6f); //Avoid interact immediatly with the toast
        breadParams.InteractionTriggerCollider.enabled = true;
    }
    public void BreadIsReady() //Called by timeline
    {
        item.gameObject.SetActive(true);
        item.ItemCollider.enabled = true;
        item.BreadInteractionTrigger.enabled = true;
        item.enabled = false;
        Destroy(item);
    }
}
