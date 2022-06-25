using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finallabyrinth : MonoBehaviour
{
    [SerializeField] private AIChase ai;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement playerMovement))
        {
            // end maze
            //Debug.Log("End maze!");
            //PlayerProperties.ToggleFreezeMovement( true);
            //PlayerProperties.ToggleFreezeAim(true);
            //PlayerProperties.ToggleFreezeInteraction(true);
            ai.State = AIChase.AgentState.Finished;
        }
    }
}
