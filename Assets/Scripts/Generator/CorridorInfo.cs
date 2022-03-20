using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CorridorInfo : MonoBehaviour
{
    private AIChase aiChase;
    [SerializeField]private CorridorType corridorType;
    [SerializeField] private NavMeshLink meshLink;
    [SerializeField] private Waypoint[] waypointsCopycat;
    public enum CorridorType
    {
        Straight, RightCurve
    }
    private void Awake()
    {
        aiChase = FindObjectOfType<AIChase>();
    }
    private void OnEnable() // When is enabled on scene
    {
        aiChase.AddMoreDestination(waypointsCopycat);
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
