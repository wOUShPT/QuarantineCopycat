using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum WaypointType
    {
        LateralRandomizedIn, Circle
    }
    [SerializeField]private WaypointType waypointType;
    public bool IsRandomizedOnCircle()
    {
        return waypointType == WaypointType.Circle;
    }

}
