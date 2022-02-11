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
        item.ItemCollider.isTrigger = true;
        plateParamsStack.Push(new PlateSpotParams(transform, item));
        item = null;
    }
}
