using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private Animator leftDoorAnimator;
    private Animator rightDoorAnimator;
    private delegate void DoorsInteraction();
    private DoorsInteraction doorsInteraction;
    private bool wasInteracted = false;
    
    private void Awake()
    {
        //Assign the animators and Open doors to elegate
        if(leftDoor!= null)
        {
            leftDoorAnimator = leftDoor.GetComponent<Animator>();
        }
        if(rightDoor != null)
        {
            rightDoorAnimator = rightDoor.GetComponent<Animator>();
        }
        doorsInteraction += OpenDoors;
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        if (wasInteracted)
        {
            return;
        }
        doorsInteraction?.Invoke();
        wasInteracted = true;
    }
    public void ExitInteract()
    {
        wasInteracted = false;
    }
    private void OpenDoors()
    {
        if ((rightDoorAnimator != null && AnimatorIsPlaying(rightDoorAnimator)))
        {
            return; //Animators are playing
        }
        if ((leftDoorAnimator != null && AnimatorIsPlaying(leftDoorAnimator)))
        {
            return;
        }
        //Open both doors
        if ( leftDoorAnimator != null)
        {
            leftDoorAnimator.Play("LeftDoorOpen");
        }
        if( rightDoorAnimator != null)
        {
            rightDoorAnimator.Play("RightDoorOpen");
        }
        //detach delegate to OpenDoors and attach closed doors to delegate
        doorsInteraction -= OpenDoors;
        doorsInteraction += CloseDoors;
    }
    private void CloseDoors()
    {
        if ((rightDoorAnimator != null && AnimatorIsPlaying(rightDoorAnimator)))
        {
            return; //Animators are playing
        }
        if((leftDoorAnimator != null && AnimatorIsPlaying(leftDoorAnimator)))
        {
            return;
        }
        //Close both doors
        if (leftDoorAnimator != null)
        {
            leftDoorAnimator.Play("LeftDoorClose");
        }
        if (rightDoorAnimator != null)
        {
            rightDoorAnimator.Play("RightDoorClose");
        }
        //detach delegate to CloseDoors and attach open doors to delegate
        doorsInteraction -= CloseDoors;
        doorsInteraction += OpenDoors;
    }
    private bool AnimatorIsPlaying( Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

}
