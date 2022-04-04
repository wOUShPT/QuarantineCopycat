using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class PickupItem : InteractableBehaviour
{
    [SerializeField] private bool canBeOnInventory = true;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private UnityEvent effect;
    [SerializeField] private EventReference _FMODPickupEvent;
    private EventInstance _eventInstance;

    private void Start()
    {
        if (_FMODPickupEvent.IsNull)
        {
            return;
        }
        _eventInstance = FMODUnity.RuntimeManager.CreateInstance(_FMODPickupEvent);
        _eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
    }

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
        effect.Invoke();
        _eventInstance.start();
        gameObject.SetActive(false);
    }
}
