using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] 
    private PlayerRaycast _playerRaycast;
    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask interactablesLayer;
    private UIManager _uiManager;
    private RaycastHit[] _hitResults;
    private Transform raycastTransform;
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        
        _hitResults = new RaycastHit[1];

        _playerRaycast.raycastCallback += InteractionPrompt;
    }

    /*void FixedUpdate()
    {
        if (PlayerProperties.FreezeInteraction)
        {
            return;
        }

        _hudReferences.ToggleInteractionPrompt(false);
        int hits = Physics.RaycastNonAlloc(Camera.main.transform.position, Camera.main.transform.forward, _hitResults, range, interactablesLayer);
        if (hits == 0)
        {
            return;
        }
        
        if (_hitResults[0].transform.TryGetComponent(out IInteractable interactable))
        {
            _hudReferences.ToggleInteractionPrompt(true);
            if (InputManager.Instance.PlayerInput.Interaction)
            {
                interactable.Interact();
            }
        }
    }*/


    private void OnDisable()
    {
        if (_uiManager.interactionPrompt != null)
        {
            _uiManager.ToggleInteractionPrompt(false);
        }
    }

    void InteractionPrompt(RaycastHit hit)
    {
        if (PlayerProperties.FreezeInteraction)
        {
            return;
        }
        
        _uiManager.ToggleInteractionPrompt(false);
        
        if (hit.transform.TryGetComponent(out IInteractable interactable)  && Vector3.Distance(Camera.main.transform.position, hit.point) <= (interactable.InteractionDistance() == 0 ? range : interactable.InteractionDistance()))
        {
            
            _uiManager.ToggleInteractionPrompt(true);
            if (InputManager.Instance.PlayerInput.Interaction)
            {
                //Being interactive
                CheckChangedRaycastTarget(hit.transform);
                interactable.Interact();
            }
            else
            {
                CheckChangedRaycastTarget(null);
            }
        }
        else
        {
            CheckChangedRaycastTarget(null);
        }
    }
    private void CheckChangedRaycastTarget(Transform _targetTransform)
    {
        
        if(_targetTransform != raycastTransform && raycastTransform != null)
        {
            //Changed target and raycasTransform is not null
            if (raycastTransform.TryGetComponent(out IInteractable interactable))
            {
                interactable.ExitInteract();
            }
        }
        raycastTransform = _targetTransform;
    }
}
