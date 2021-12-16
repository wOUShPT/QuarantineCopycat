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

    public void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        interactionLayer = this.gameObject.layer;
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
        gameObject.layer = interactionLayer;
    }

    public void DisplayOutline()
    {
        if (gameObject.layer == outlineLayer)
            return;
        gameObject.layer = outlineLayer;
    }
}
