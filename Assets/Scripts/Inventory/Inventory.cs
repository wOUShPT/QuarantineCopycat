using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<PickUpItemBehaviour> itemList;
    public Inventory()
    {
        itemList = new List<PickUpItemBehaviour>();

    }
    public void AddItem(PickUpItemBehaviour item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

    }
    public PickUpItemBehaviour CheckHasItem(PickUpItemBehaviour.PickUpObjectType objectType)
    {
        if(itemList != null && itemList.Count > 0)
        {
            PickUpItemBehaviour item = objectType == PickUpItemBehaviour.PickUpObjectType.Any ? itemList.Where(t => t.ObjectType != PickUpItemBehaviour.PickUpObjectType.Toothbrush).FirstOrDefault()  : itemList.Where( t=> t.ObjectType == objectType).FirstOrDefault();
            if(item != null)
            {
                RemoveItem(item);
                return item;
            }
        }
        return null;
    }
    public void RemoveItem(PickUpItemBehaviour item)
    {
        itemList.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<PickUpItemBehaviour> GetItemList()
    {
        return itemList;
    }
}
