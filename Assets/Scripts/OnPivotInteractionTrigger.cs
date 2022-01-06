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
    private int interactionLayer;
    [SerializeField] private int outlineLayer = 11;
    [SerializeField] protected OtherGameobjectOutline[] otherGameobjectOutlineArray;
    [System.Serializable]
    public class OtherGameobjectOutline
    {
        public GameObject outlineObject;
        public int interactionTrigger;
    }

    public void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
        interactionLayer = gameObject.layer;
        if (otherGameobjectOutlineArray.Length != 0)
        {
            foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
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
        _playerMovement.MoveToTarget(interactionPivot, 0.02f);
        _playerMovement.isOnActionPivot = false;
        StartCoroutine(WaitAndRaise());
    }

    public void ExitInteract()
    {
        FadeOutline.FadeeOutOutline();
        gameObject.layer = interactionLayer;
        if (otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = outlineObject.interactionTrigger;
        }
    }

    IEnumerator WaitAndRaise()
    {
        _uiManager.ToggleInteractionPrompt(false);
        yield return new WaitUntil(() => _playerMovement.isOnActionPivot);
        gameEvent.Raise();
        _playerMovement.isOnActionPivot = false;
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
            outlineObject.outlineObject.layer = outlineLayer;
        }
    }
}
