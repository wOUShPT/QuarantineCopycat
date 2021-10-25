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
    
    private void Awake()
    {
        //Assign the animators and Open doors to elegate
        leftDoorAnimator = leftDoor.GetComponent<Animator>();
        rightDoorAnimator = rightDoor.GetComponent<Animator>();
        doorsInteraction += OpenDoors;
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        doorsInteraction?.Invoke();
    }
    private void OpenDoors()
    {
        if( AnimatorIsPlaying(rightDoorAnimator) || AnimatorIsPlaying(leftDoorAnimator))
        {
            return; //Animators are playing
        }
        //Open both doors
        if( leftDoorAnimator != null)
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
        if (AnimatorIsPlaying(rightDoorAnimator) || AnimatorIsPlaying(leftDoorAnimator))
        {
            return; //Animators are playing
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
