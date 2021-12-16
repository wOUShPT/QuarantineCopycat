using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPhone : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionDistance = 0f;
    private bool wasInteraction = false;
    private PlayerPhone playerPhone;
    private delegate void PickPhoneAction();
    private PickPhoneAction phoneAction;
    private InteractionTrigger interactionTrigger;
    private int interactionLayer;
    [SerializeField] private int outlineLayer = 11;
    private void Awake()
    {
        playerPhone = FindObjectOfType<PlayerPhone>();
        interactionTrigger = GetComponentInChildren<InteractionTrigger>();
        interactionLayer = gameObject.layer;
    }
    // Start is called before the first frame update
    void Start()
    {
        phoneAction = PickPhone;
    }
    public void ExitInteract()
    {
        wasInteraction = false;
        gameObject.layer = interactionLayer;
    }

    public void Interact()
    {
        if (wasInteraction)
        {
            return;
        }
        phoneAction?.Invoke();
    }
    private void PickPhone()
    {
        playerPhone.ToogleHasPhoneToTrue();
        interactionTrigger.Interact();
        phoneAction = null;
        wasInteraction = true;
        this.gameObject.SetActive(false);
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }
    public void DisplayOutline()
    {
        if (this.gameObject.layer == outlineLayer)
            return;
        gameObject.layer = outlineLayer;
    }

}
