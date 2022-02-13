using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpPhone : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionDistance = 0f;
    public UnityEvent effect;
    private bool wasInteraction = false;
    private PlayerPhone playerPhone;
    private delegate void PickPhoneAction();
    private PickPhoneAction phoneAction;
    private InteractionTrigger interactionTrigger;
    private int interactionLayer;
    [SerializeField] private int outlineLayer = 11;
    private bool isOutline;
    [SerializeField] private OtherGameobjectOutline[] otherGameobjectOutlineArray;
    [System.Serializable]
    public class OtherGameobjectOutline
    {
        public GameObject outlineObject;
        public int interactionTrigger;
    }
    private void Awake()
    {
        playerPhone = FindObjectOfType<PlayerPhone>();
        interactionTrigger = GetComponentInChildren<InteractionTrigger>();
        interactionLayer = gameObject.layer;
    }
    // Start is called before the first frame update
    void Start()
    {
        phoneAction = PickPhone;
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
        FadeOutline.FadeeOutOutline();
        wasInteraction = false;
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
        if (wasInteraction)
        {
            return;
        }
        phoneAction?.Invoke();
    }
    private void PickPhone()
    {
        playerPhone.ToggleHasPhoneToTrue();
        interactionTrigger.Interact();
        phoneAction = null;
        wasInteraction = true;
        effect.Invoke();
        this.gameObject.SetActive(false);
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }
    public void DisplayOutline()
    {
        if (this.gameObject.layer == outlineLayer)
            return;
        FadeOutline.Instance.FadeInOutline();
        gameObject.layer = outlineLayer;
        if (otherGameobjectOutlineArray.Length == 0)
            return;
        foreach(OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = outlineLayer;
        }
    }

}
