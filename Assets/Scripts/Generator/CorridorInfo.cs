using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CorridorInfo : MonoBehaviour
{
    [SerializeField] private NavMeshSurface meshSurface;
    [SerializeField]private CorridorType corridorType;
    [SerializeField] private NavMeshLink meshLink;
    private void Awake()
    {
        meshSurface = GetComponent<NavMeshSurface>();
        //SetBake();
    }
    
    public enum CorridorType
    {
        Straight, RightCurve
    }

    public void SetBake()
    {
        meshSurface.BuildNavMesh();
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
