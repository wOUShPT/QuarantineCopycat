using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour , IInteractable
{
    public GameEvent gameEvent;
    
    public void Interact()
    {
        gameEvent.Raise();
    }
}
