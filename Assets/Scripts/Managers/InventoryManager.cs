using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static Inventory inventory;
    private UI_Inventory _uiInventory;

    void Awake()
    {
        inventory = new Inventory();
        _uiInventory = FindObjectOfType<UI_Inventory>();
        _uiInventory.SetInventory();
    }
}

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<ItemType> _itemList;
    
    public Inventory()
    {
        _itemList = new List<ItemType>();
    }
    public void AddItem(ItemType itemType)
    {
        _itemList.Add(itemType);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public bool CheckHasItem(ItemType itemType)
    {
        return _itemList.Any(item => item == itemType);
    }
    public void RemoveItem(ItemType itemType)
    {
        _itemList.Remove(itemType);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<ItemType> GetItemList()
    {
        return _itemList;
    }
}
