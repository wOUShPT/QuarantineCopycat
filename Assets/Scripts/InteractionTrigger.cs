using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour , IInteractable
{
    public GameEvent gameEvent;
    private HUDReferences _hudReferences;

    public void Awake()
    {
        _hudReferences = FindObjectOfType<HUDReferences>();
    }

    public void Interact()
    {
        gameEvent.Raise();
        _hudReferences.ToggleInteractionPrompt(false);
    }
}
