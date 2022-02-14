using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothPlace : ItemSpotBehaviour
{
    [SerializeField] protected int maxNumberCloths = 3;
    protected override void Awake()
    {
        clothParamsStack = new Stack<ClothParams>();
        base.Awake();
        dropObjectType = PickUpItemBehaviour.PickUpObjectType.Cloth;
    }

    protected override void CheckPlayerHasItem()
    {
        PickUpItemBehaviour clothBehaviour = playerPickUp.GetInventory().CheckHasItem(DropObjectType);
        if (clothParamsStack.Count >= maxNumberCloths)
        {
            return;
        }
        if (clothBehaviour == null)
        {
            return; //can't put an cloth on a book spot
        }
        item = clothBehaviour;
        playerPickUp.BreakConnection(item); // Drop book
        PlaceItemToSpot();
    }

    protected override void PlaceItemToSpot()
    {
        item.transform.SetParent(holderPositionArray[clothParamsStack.Count]);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.Euler(Vector3.zero);
        item.transform.localScale = item.InitialScale;
        item.ItemCollider.isTrigger = true;
        clothParamsStack.Push(new ClothParams(holderPositionArray[clothParamsStack.Count], item));
        item = null;
    }
}
