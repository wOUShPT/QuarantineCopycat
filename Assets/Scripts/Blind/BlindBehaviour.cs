using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BlindBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionDistance = 0f;
    private bool isClosed = true;
    private bool wasInteracted = false;

    private Animator _animator;
    //Layer
    protected int interactionLayer;
    [SerializeField] protected int outlineLayer = 11;
    //delegate
    private delegate void BlindAction();
    private BlindAction blindAction;
    public float InteractionDistance() //distance of the interaction
    {
        return interactionDistance;
    }
    [SerializeField] private OtherGameobjectOutline[] otherGameobjectOutlineArray;
    [System.Serializable]
    public class OtherGameobjectOutline
    {
        public GameObject outlineObject;
        public int interactionTrigger;
    }
    void Awake()
    {
        _animator = GetComponent<Animator>();
        interactionLayer = gameObject.layer;
        if (otherGameobjectOutlineArray.Length != 0)
        {
            foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
            {
                outlineObject.interactionTrigger = outlineObject.outlineObject.layer;
            }
        }
    }

    public void ExitInteract()
    {
        //FadeOutline.Instance.FadeeOutOutline();
        wasInteracted = false;
        gameObject.layer = interactionLayer;
        if (otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = outlineObject.interactionTrigger;
        }
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
        _animator.Play("StackOpen");
        isClosed = false;
    }
    private void CloseBlind()
    {
        _animator.Play("StackClose");
        isClosed = true;
    }
    public void DisplayOutline()
    {
        if (gameObject.layer == outlineLayer)
            return;
        FadeOutline.Instance.FadeInOutline();
        gameObject.layer = outlineLayer;
        if (otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = outlineLayer;
        }
    }

}
