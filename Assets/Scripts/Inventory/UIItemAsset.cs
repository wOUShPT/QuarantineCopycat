using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Asset")]
public class UIItemAsset : ScriptableObject
{
    [SerializeField]private ItemType _itemType;
    public ItemType ObjectType => _itemType;
    [SerializeField] private Sprite sprite;

    public Sprite GetSprite()
    {
        return sprite;
    }
    
}

public enum PickUpObjectType
{
    
}
