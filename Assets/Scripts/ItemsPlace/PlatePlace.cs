using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePlace : ItemSpotBehaviour
{
    [SerializeField] protected int maxNumberPlates = 5;
    // Start is called before the first frame update
    protected override void Awake()
    {
        dropObjectType = PickUpItemBehaviour.PickUpObjectType.Plate;
        base.Awake();
        plateParamsStack = new Stack<PlateSpotParams>();
    }

    protected override void CheckPlayerHasItem()
    {
        if (CheckLaundryHasPlates())
        {
            TakeItemToPlayer();
            return;
        }
        PickUpItemBehaviour plateBehaviour = playerPickUp.GetInventory().CheckHasItem(DropObjectType);
        if (plateBehaviour == null || !CheckCanPlaceItem(plateBehaviour))
        {
            return;
        }
        item = plateBehaviour;
        item.PickedUp = false;
        playerPickUp.BreakConnection(item); // Drop book
        PlaceItemToSpot();
    }
    private bool CheckLaundryHasPlates() //Check the laundry has cloths
    {
        if (plateParamsStack.Count > 0)
        {
            return true; // has at least one cloth
        }
        return false; // no cloths
    }
    private bool CheckCanPlaceItem(PickUpItemBehaviour plateBehaviour)
    {
        if (plateParamsStack.Count >= maxNumberPlates)
        {
            return false;
        }
        if (plateBehaviour.ObjectType != DropObjectType || !plateBehaviour.IsPlateWashed)
        {
            return false;
        }
        if (!plateBehaviour.IsPlateWashed)
        {
            return false; //Is not washed yet
        }
        return true;
    }

    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(this.transform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.Euler(Vector3.zero);
        item.transform.localScale = item.InitialScale;
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.isTrigger = true;
        plateParamsStack.Push(new PlateSpotParams(transform, item));
        item = null;
    }

    protected override void TakeItemToPlayer()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null) // it's a book player has picked
        {
            CheckPlayerHasItem();
        }
        else // Player took a plate
        {
            PlateSpotParams platesParams = plateParamsStack.Pop();
            platesParams.itemBehaviour.ItemCollider.isTrigger = false;
            platesParams.itemBehaviour.ItemRigidbody.isKinematic = true;
            playerPickUp.GetPickedupObject(platesParams.itemBehaviour);
        }
    }
}
