using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour , IInteractable
{
    public float interactionDistance;
    public GameEvent gameEvent;
    private UIManager _uiManager;

    public void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
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

    }
}
