using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupItem : InteractableBehaviour
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private UnityEvent effect;

    public override void Interact()
    {
        InventoryManager.inventory.AddItem(_itemType);
        gameObject.SetActive(false);
        effect.Invoke();
        //interactDelegate?.Invoke();
    }
}
