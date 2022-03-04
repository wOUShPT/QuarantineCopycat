using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : InteractableBehaviour
{
    public GameEvent gameEvent;
    private UIManager _uiManager;

    protected override void Awake()
    {
        base.Awake();
        _uiManager = FindObjectOfType<UIManager>();
    }

    public override void Interact()
    {
        if (!enabled)
            return;
        gameEvent.Raise();
        _uiManager.ToggleInteractionPrompt(false);
    }
}
