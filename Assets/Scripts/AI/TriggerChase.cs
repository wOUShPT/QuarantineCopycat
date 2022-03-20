using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChase : MonoBehaviour
{
    public EventHandler OnPlayerInsideTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.transform.rotation = Quaternion.Euler(Vector3.zero);
            //Player inside the trigger area
            OnPlayerInsideTrigger?.Invoke(this,EventArgs.Empty);
            this.gameObject.SetActive(false);
        }
    }
}
