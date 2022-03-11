using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupItem : InteractableBehaviour
{
    [SerializeField] private bool canBeOnInventory = true;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private UnityEvent effect;

    public override void Interact()
    {
        if (canBeOnInventory)
        {
            InventoryManager.Inventory.AddItem(_itemType);   
        }
        gameObject.SetActive(false);
        effect.Invoke();
    }
}
