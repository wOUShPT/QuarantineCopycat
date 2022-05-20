using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finallabyrinth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement playerMovement))
        {
            // end maze
            
        }
    }
}
