using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask interactablesLayer;

    private HUDReferences _hudReferences;
    private RaycastHit[] hitResults;
    void Awake()
    {
        _hudReferences = FindObjectOfType<HUDReferences>();
        hitResults = new RaycastHit[1];
    }
    
    void FixedUpdate()
    {
        if (PlayerProperties.FreezeInteraction)
        {
            return;
        }
        
        _hudReferences.ToggleInteractionPrompt(false);
        int hits = Physics.RaycastNonAlloc(Camera.main.transform.position, Camera.main.transform.forward, hitResults, range, interactablesLayer);
        if (hits == 0)
        {
            return;
        }
        
        if (hitResults[0].transform.TryGetComponent(out IInteractable interactable))
        {
            _hudReferences.ToggleInteractionPrompt(true);
            if (InputManager.Instance.PlayerInput.Interaction)
            {
                interactable.Interact();
            }
        }
    }


    private void OnDisable()
    {
        if (_hudReferences.interactionPrompt != null)
        {
            _hudReferences.ToggleInteractionPrompt(false);
        }
    }
}
