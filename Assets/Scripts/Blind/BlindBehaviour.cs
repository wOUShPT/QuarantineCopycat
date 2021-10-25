using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BlindBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionDistance = 0f;
    private bool isClosed = true;
    private bool wasInteracted = false;
    private List<Animator> animatorchildArray;

    //delegate
    private delegate void BlindAction();
    private BlindAction blindAction;
    public float InteractionDistance() //distance of the interaction
    {
        return interactionDistance;
    }

    void Awake()
    {
        animatorchildArray = new List<Animator>(); //assign list
        foreach( Transform child in transform)
        {
            animatorchildArray.Add(child.GetComponent<Animator>());
        }
    }

    public void ExitInteract()
    {
        wasInteracted = false;
    }

    public void Interact()
    {
        if (CheckWasInteracted())
            return;
        if (isClosed)
        {
            blindAction = ( OpenBlind);
        }
        else
        {
            blindAction = CloseBlind;
        }
        blindAction?.Invoke();
        wasInteracted = true;
    }
    private bool CheckWasInteracted()
    {
        if(wasInteracted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OpenBlind()
    {
        foreach( Animator animator in animatorchildArray)
        {
            animator.Play("StackOpen");
        }
        isClosed = false;
    }
    private void CloseBlind()
    {
        foreach (Animator animator in animatorchildArray)
        {
            animator.Play("StackClose");
        }
        isClosed = true;
    }

}
