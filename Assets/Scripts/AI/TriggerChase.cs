using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChase : MonoBehaviour
{
    public EventHandler OnPlayerInsideTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Player inside the trigger area
            OnPlayerInsideTrigger?.Invoke(this,EventArgs.Empty);
        }
    }
}
