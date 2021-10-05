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
        _hudReferences.interactionPrompt.SetActive(false);
        int hits = Physics.RaycastNonAlloc(Camera.main.transform.position, Camera.main.transform.forward, hitResults, range, interactablesLayer);
        if (hits == 0)
        {
            return;
        }
        
        if (hitResults[0].transform.TryGetComponent(out IInteractable interactable))
        {
            _hudReferences.interactionPrompt.SetActive(true);
            if (InputManager.Instance.PlayerInput.Interaction > 0)
            {
                interactable.Interact();
            }
        }
    }
}
