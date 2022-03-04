using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpPhone : InteractableBehaviour
{
    public UnityEvent effect;
    private bool _wasInteraction;
    private PlayerPhone _playerPhone;
    private delegate void PickPhoneAction();
    private PickPhoneAction _phoneAction;
    private InteractionTrigger _interactionTrigger;

    protected override void Awake()
    {
        base.Awake();
        _playerPhone = FindObjectOfType<PlayerPhone>();
        _interactionTrigger = GetComponentInChildren<InteractionTrigger>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _wasInteraction = false;
        _phoneAction = PickPhone;
    }
    
    public override void Interact()
    {
        if (_wasInteraction)
        {
            return;
        }
        _phoneAction?.Invoke();
    }
    private void PickPhone()
    {
        _playerPhone.ToggleHasPhoneToTrue();
        _interactionTrigger.Interact();
        _phoneAction = null;
        _wasInteraction = true;
        effect.Invoke();
        gameObject.SetActive(false);
    }
}
