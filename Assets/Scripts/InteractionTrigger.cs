using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour , IInteractable
{
    public float interactionDistance;
    public GameEvent gameEvent;
    private HUDReferences _hudReferences;

    public void Awake()
    {
        _hudReferences = FindObjectOfType<HUDReferences>();
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        gameEvent.Raise();
        _hudReferences.ToggleInteractionPrompt(false);
    }

    public void ExitInteract()
    {

    }
}
