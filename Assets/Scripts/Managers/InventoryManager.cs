using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static NewInventory inventory;
    private UI_NewInventory _uiInventory;

    void Awake()
    {
        inventory = new NewInventory();
        _uiInventory = FindObjectOfType<UI_NewInventory>();
        _uiInventory.SetInventory();
    }
}

public class NewInventory
{
    public event EventHandler OnItemListChanged;
    private List<ItemType> itemList;
    
    public NewInventory()
    {
        itemList = new List<ItemType>();
    }
    public void AddItem(ItemType itemType)
    {
        itemList.Add(itemType);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public ItemType CheckHasItem(ItemType itemType)
    {
        return null;
    }
    public void RemoveItem(ItemType itemType)
    {
        itemList.Remove(itemType);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<ItemType> GetItemList()
    {
        return itemList;
    }
}
