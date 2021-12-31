using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Asset")]
public class UIItemAsset : ScriptableObject
{
    [SerializeField]private PickUpItemBehaviour.PickUpObjectType objectType;
    public PickUpItemBehaviour.PickUpObjectType ObjectType => objectType;
    [SerializeField] private Sprite sprite;

    public Sprite GetSprite()
    {
        return sprite;
    }
    
}
