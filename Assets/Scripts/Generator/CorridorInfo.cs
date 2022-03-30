using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CorridorInfo : MonoBehaviour
{
    [SerializeField]private CorridorType corridorType;
    [SerializeField] private NavMeshLink meshLink;
    public enum CorridorType
    {
        Straight, RightCurve
    }
    public void UpdateLink()
    {
        meshLink.UpdateLink();
    }
    public CorridorType GetCorridorType()
    {
        return corridorType;
    }
}
