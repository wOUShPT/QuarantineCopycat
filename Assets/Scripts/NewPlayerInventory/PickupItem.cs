using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] protected float interactionDistance;
    
    protected delegate void InteractDelegate();
    protected InteractDelegate interactDelegate;

    protected int interactionLayer;
    [SerializeField] protected int outlineLayer = 11;
    [SerializeField] protected int fakeShaderOutlineLayer = 12;

    [Serializable]
    private class OtherGameobjectOutline
    {
        public GameObject outlineObject;
        public int interactionTrigger;
        public bool isFakeshader;
    }
    
    [SerializeField] 
    private OtherGameobjectOutline[] _otherGameobjectOutlineArray;
    
    
    protected virtual void Awake()
    {
        interactionLayer = gameObject.layer;
        if (_otherGameobjectOutlineArray.Length != 0)
        {
            foreach (OtherGameobjectOutline outlineObject in _otherGameobjectOutlineArray)
            {
                outlineObject.interactionTrigger = outlineObject.outlineObject.layer;
            }
        }
    }
    
    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        InventoryManager.inventory.AddItem(_itemType);
        gameObject.SetActive(false);
        //interactDelegate?.Invoke();
    }

    public void ExitInteract()
    {
        FadeOutline.FadeeOutOutline();
        gameObject.layer = interactionLayer;
        if (_otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in _otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = outlineObject.interactionTrigger;
        }
    }

    public void DisplayOutline()
    {
        if (gameObject.layer == outlineLayer)
            return;
        FadeOutline.Instance.FadeInOutline();
        gameObject.layer = outlineLayer;
        if (_otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in _otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = !outlineObject.isFakeshader ? outlineLayer : fakeShaderOutlineLayer;
        }
    }
}
