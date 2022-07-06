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
    private Camera _camera;
    private Transform raycastTransform;
    void Start()
    {
        _camera = Camera.main;
        _playerRaycast.raycastCallback += InteractionPrompt;
    }
    
    private void OnDisable()
    {
        
    }

    void InteractionPrompt(RaycastHit hit)
    {
        if (PlayerProperties.FreezeInteraction)
        {
            HideOutline();
            CheckChangedRaycastTarget(null);
            return;
        }

        if (hit.transform.TryGetComponent(out InteractableBehaviour interactable)  && Vector3.Distance(_camera.transform.position, hit.point) <= (interactable.InteractionDistance() == 0 ? range : interactable.InteractionDistance()))
        {
            interactable.DisplayOutline();
            CheckChangedRaycastTarget(hit.transform);
            if (InputManager.Instance.PlayerInput.Interaction)
            {
                //Being interactive
                interactable.Interact();
            }
        }
        else
        {
            HideOutline();
            CheckChangedRaycastTarget(null);
        }
    }
    private void HideOutline()
    {
        if (raycastTransform != null && raycastTransform.TryGetComponent(out InteractableBehaviour iinteractable))
        {
            iinteractable.HideOutline();
        }
    }
    private void CheckChangedRaycastTarget(Transform _targetTransform)
    {
        
        if(_targetTransform != raycastTransform && raycastTransform != null)
        {
            //Changed target and raycastTransform is not null
            if (raycastTransform.TryGetComponent(out InteractableBehaviour interactable))
            {
                interactable.HideOutline();
            }
        }
        raycastTransform = _targetTransform;
    }
}
