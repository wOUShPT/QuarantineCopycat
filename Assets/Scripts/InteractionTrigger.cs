using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour , IInteractable
{
    public float interactionDistance;
    public GameEvent gameEvent;
    private UIManager _uiManager;
    private int interactionLayer;
    [SerializeField] private int outlineLayer = 11;
    [SerializeField] private int fakeMashOutlineLayer = 12;
    [SerializeField] private OtherGameobjectOutline[] otherGameobjectOutlineArray;
    [System.Serializable]
    public class OtherGameobjectOutline
    {
        public GameObject OutlineObject;
        public int InteractionTrigger;
        public bool IsFakeMaterial;
    }

    public void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        interactionLayer = this.gameObject.layer;
        if (otherGameobjectOutlineArray.Length != 0)
        {
            foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
            {
                outlineObject.InteractionTrigger = outlineObject.OutlineObject.layer;
            }
        }
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        gameEvent.Raise();
        _uiManager.ToggleInteractionPrompt(false);
    }

    public void ExitInteract()
    {
        FadeOutline.FadeeOutOutline();
        gameObject.layer = interactionLayer;
        if (otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
        {
            outlineObject.OutlineObject.layer = outlineObject.InteractionTrigger;
        }
    }

    public void DisplayOutline()
    {
        if (gameObject.layer == outlineLayer)
            return;
        FadeOutline.Instance.FadeInOutline();
        gameObject.layer = outlineLayer;
        if (otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
        {
            outlineObject.OutlineObject.layer = !outlineObject.IsFakeMaterial ? outlineLayer : fakeMashOutlineLayer;
        }
    }
}
