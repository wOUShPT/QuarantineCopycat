using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBedInteraction : MonoBehaviour
{
    private BoxCollider boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        EnableMakeBedInteraction();
    }

    public void EnableMakeBedInteraction() // by start and timeline
    {
        boxCollider.enabled = true;
    }
    public void DisableMakeBedInteraction() // By timeline
    {
        boxCollider.enabled = false;
    }
}
