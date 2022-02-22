using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CorridorInfo : MonoBehaviour
{
    [SerializeField] private NavMeshSurface meshSurface;
    [SerializeField]private CorridorType corridorType;
    private void Awake()
    {
        meshSurface = GetComponent<NavMeshSurface>();
        SetBake();
    }
    private void OnEnable()
    {
        
    }
    public enum CorridorType
    {
        Straight, RightCurve
    }

    public void SetBake()
    {
        meshSurface.BuildNavMesh();
    }

    public CorridorType GetCorridorType()
    {
        return corridorType;
    }
}
