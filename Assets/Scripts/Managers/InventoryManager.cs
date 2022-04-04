using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using EventHandler = System.EventHandler;

public class InventoryManager : MonoBehaviour
{
    public static Inventory Inventory;
    private UI_Inventory _uiInventory;
    [SerializeField] private EventReference _FMODInventoryStingerEvent;

    void Awake()
    {
        Inventory = new Inventory();
        _uiInventory = FindObjectOfType<UI_Inventory>();
        _uiInventory.SetInventory();
        Inventory.SetFMODEvent = _FMODInventoryStingerEvent;
    }
}

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<ItemType> _itemList;
    public EventReference FMODInventoryStringerEvent;
    private EventInstance _eventInstance;

    public EventReference SetFMODEvent
    {
        set
        {
            if (value.IsNull)
            {
                return;
            }
            FMODInventoryStringerEvent = value;
            _eventInstance = FMODUnity.RuntimeManager.CreateInstance(FMODInventoryStringerEvent);
        }
    }

    public Inventory()
    {
        _itemList = new List<ItemType>();
    }
    public void AddItem(ItemType itemType)
    {
        if (!CheckHasItem(itemType))
        {
            _itemList.Add(itemType);
            _eventInstance.start();
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public bool CheckHasItem(ItemType itemType)
    {
        return _itemList.Any(item => item == itemType);
    }
    public void RemoveItem(ItemType itemType)
    {
        if (CheckHasItem(itemType))
        {
            _itemList.Remove(itemType);
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public List<ItemType> GetItemList()
    {
        return _itemList;
    }
}
