using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPivotInteractionTrigger : MonoBehaviour , IInteractable
{
    private PlayerMovement _playerMovement;
    public Transform interactionPivot;
    public float interactionDistance;
    public GameEvent gameEvent;
    private UIManager _uiManager;

    public void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        _playerMovement.MoveToTarget(interactionPivot, 0.02f);
        _playerMovement.isOnActionPivot = false;
        StartCoroutine(WaitAndRaise());
    }

    public void ExitInteract()
    {

    }

    IEnumerator WaitAndRaise()
    {
        _uiManager.ToggleInteractionPrompt(false);
        yield return new WaitUntil(() => _playerMovement.isOnActionPivot);
        gameEvent.Raise();
        _playerMovement.isOnActionPivot = false;
    }
}
