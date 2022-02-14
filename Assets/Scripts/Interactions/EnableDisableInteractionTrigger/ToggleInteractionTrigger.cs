using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleInteractionTrigger : MonoBehaviour
{
    protected PlayerPickUpBehaviour pickupBehaviour;
    protected Transform ItemToInteractionTriggerPivot;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        pickupBehaviour = FindObjectOfType<PlayerPickUpBehaviour>();
    }
    //Abstract classes in order to all parents having the same methods
    public abstract void CheckPlayeerHasToothSpecificItem();
}
