using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CadreBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionDistance = 0f;
    private bool wasInteractable = false;
    [SerializeField]private bool isSeeing;

    [SerializeField] private GameEvent exitCadre;
    private delegate void ActionInteractionDelegate();
    private ActionInteractionDelegate interactionDelegate;
    void Awake()
    {
        interactionDelegate = PlayerStartSeeingCadre;
    }
    public void ExitInteract()
    {
        wasInteractable = false;
    }

    public void Interact()
    {
        if (wasInteractable)
        {
            return;
        }
        interactionDelegate?.Invoke();
        wasInteractable = true;
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSeeing)
            return;
        PlayerSeeingtheCadre();
    }

    private void PlayerStartSeeingCadre()
    {
        //Player is now viewing the portrait/cadre
        isSeeing = true;
        //Freeze Player
        PlayerProperties.FreezeAim = true;
        PlayerProperties.FreezeInteraction = true;
        PlayerProperties.FreezeMovement = true;
        interactionDelegate = null;
    }
    private void PlayerSeeingtheCadre()
    {
        if (InputManager.Instance.PlayerInput.ExitInteraction)
        {
            //Stop viewing the cadre
            isSeeing = false;
            exitCadre.Raise();
            PlayerProperties.FreezeAim = false;
            PlayerProperties.FreezeInteraction = false;
            PlayerProperties.FreezeMovement = false;
        }
    }
}
