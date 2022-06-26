using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FMODFloor : MonoBehaviour
{
    [SerializeField] private EventReference floorEventReference;

    public EventReference GetEventReference()
    {
        return floorEventReference;
    }
}
