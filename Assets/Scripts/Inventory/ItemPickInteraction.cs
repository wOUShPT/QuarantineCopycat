using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickInteraction : InteractableBehaviour
{
    [SerializeField] private bool canBeOnInventory = true;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private UnityEvent effect;
    [SerializeField] private EventReference _FMODPickupEvent;

    public override void Interact()
    {
        if (!CanInteract)
        {
            return;
        }
        
        if (canBeOnInventory)
        {
            InventoryManager.Inventory.AddItem(_itemType);   
        }
        
        if (!_FMODPickupEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(_FMODPickupEvent, transform.position);
        }
        
        effect.Invoke();
        gameObject.SetActive(false);
    }
}
