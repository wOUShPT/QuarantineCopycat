using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemRecieverInteraction : InteractableBehaviour
{
    [SerializeField] private ItemType _item;
    [SerializeField] private UnityEvent effect;
    [SerializeField] private EventReference _FMODPlaceEvent;
    private bool _wasInteracted;

    private void Start()
    {
        _wasInteracted = false;
    }

    public void Update()
    {
        CanInteract = InventoryManager.Inventory.CheckHasItem(_item);
    }

    public override void Interact()
    {
        if (!InventoryManager.Inventory.CheckHasItem(_item) || _wasInteracted)
        {
            return;
        }
        
        _wasInteracted = true;
        DisableInteraction();
        HideOutline();
        InventoryManager.Inventory.RemoveItem(_item);
        if (!_FMODPlaceEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(_FMODPlaceEvent, transform.position);
        }
        effect.Invoke();
    }
}
