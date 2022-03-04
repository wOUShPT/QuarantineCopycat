using System;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractableBehaviour: MonoBehaviour
{
    [Serializable]
    private class OtherGameobjectOutline
    {
        public GameObject outlineObject;
        public int interactionTrigger;
        public bool isFakeshader;
    }
    
    [SerializeField]
    protected float _interactionDistance = 2;

    [SerializeField]
    protected int interactionLayer;
    [SerializeField]
    protected int outlineLayer = 11;
    [SerializeField]
    protected int fakeShaderOutlineLayer = 12;

    protected virtual void Awake()
    {
        interactionLayer = gameObject.layer;
        if (_otherGameobjectOutlineArray.Length != 0)
        {
            foreach (OtherGameobjectOutline outlineObject in _otherGameobjectOutlineArray)
            {
                outlineObject.interactionTrigger = outlineObject.outlineObject.layer;
            }
        }
    }

    [SerializeField] 
    private OtherGameobjectOutline[] _otherGameobjectOutlineArray;
    
    public float InteractionDistance()
    {
        return _interactionDistance;
    }

    public virtual void Interact()
    {
        throw new System.NotImplementedException();
    }

    protected internal void HideOutline()
    {
        FadeOutline.FadeeOutOutline();
        gameObject.layer = interactionLayer;
        if (_otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in _otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = outlineObject.interactionTrigger;
        }
    }

    protected internal void DisplayOutline()
    {
        if (gameObject.layer == outlineLayer)
                return;
        FadeOutline.Instance.FadeInOutline();
        gameObject.layer = outlineLayer;
        if (_otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in _otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = !outlineObject.isFakeshader ? outlineLayer : fakeShaderOutlineLayer;
        }
    }
}
