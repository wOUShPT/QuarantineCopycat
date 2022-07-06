using System;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractableBehaviour: MonoBehaviour
{
    [Serializable]
    public class GameObjectOutlined
    {
        public GameObject outlineObject;
        public int interactionTrigger;
    }
    
    [HideInInspector]
    public float interactionDistance = 2;

    protected bool CanInteract = true;
    private int _defaultLayer = 10;
    private int _outlineLayer = 11;
    //[SerializeField]
    //protected int fakeShaderOutlineLayer = 12;

    protected virtual void Awake()
    {
        _defaultLayer = gameObject.layer;
        _outlineLayer = 11;
        
        
        
        if (gameObjectsOutlinedArray.Length != 0)
        {
            foreach (var outlineObject in gameObjectsOutlinedArray)
            {
                _defaultLayer = outlineObject.layer;
            }
        }
    }
    
    [HideInInspector]
    public GameObject[] gameObjectsOutlinedArray;
    
    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public virtual void Interact()
    {
        throw new System.NotImplementedException();
    }
    
    public void EnableInteraction()
    {
        CanInteract = true;
    }

    public void DisableInteraction()
    {
        CanInteract = false;
        HideOutline();
    }

    protected internal void HideOutline()
    {
        FadeOutline.FadeOutOutline();
        //gameObject.layer = interactionLayer;
        UIManager.Instance.ToggleMouseHint(false);
        if (gameObjectsOutlinedArray.Length == 0)
            return;
        foreach (var outlineObject in gameObjectsOutlinedArray)
        {
            outlineObject.layer = _defaultLayer;
        }
    }

    protected internal void DisplayOutline()
    {
        if (gameObject.layer == _outlineLayer || !CanInteract)
            return;
        FadeOutline.Instance.FadeInOutline();
        UIManager.Instance.ToggleMouseHint(true);
        //gameObject.layer = outlineLayer;
        if (gameObjectsOutlinedArray.Length == 0)
            return;
        foreach (var outlineObject in gameObjectsOutlinedArray)
        {
            outlineObject.layer = _outlineLayer;
        }
    }
}
