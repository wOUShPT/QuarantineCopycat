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
    private HUDReferences _hudReferences;
    private RaycastHit[] _hitResults;
    private Transform raycastTransform;
    void Start()
    {
        _hudReferences = FindObjectOfType<HUDReferences>();
        
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
        if (_hudReferences.interactionPrompt != null)
        {
            _hudReferences.ToggleInteractionPrompt(false);
        }
    }

    void InteractionPrompt(RaycastHit hit)
    {
        if (PlayerProperties.FreezeInteraction)
        {
            return;
        }
        
        _hudReferences.ToggleInteractionPrompt(false);
        
        if (hit.transform.TryGetComponent(out IInteractable interactable) && Vector3.Distance(Camera.main.transform.position, hit.point) <= range)
        {
            
            _hudReferences.ToggleInteractionPrompt(true);
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
            if (raycastTransform.TryGetComponent(out PickUpItemBehaviour pickUpItem))
            {
                pickUpItem.InteractExit();
            }
            else if( raycastTransform.TryGetComponent(out ItemSpot bookSpot))
            {
                bookSpot.ExitInteract();
            }
            else if( raycastTransform.TryGetComponent(out VinylDiskBehaviour vinylDisk))
            {
                vinylDisk.ExitInteraction();
            }
        }
        raycastTransform = _targetTransform;
    }
}
