using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CorridorGenerator : MonoBehaviour
{
    [SerializeField] private const float playerDistanceSpawnLevelPart = 25f;
    
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private  List<CorridorPool> levelPartList;
    private Vector3 lastEndPosition;

    private PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        lastEndPosition = levelPartStart.Find("EndPosition").position;
    }
    private void Start()
    {
        SpawnLevelPart();
    }

    private void Update()
    {
        if(Vector3.Distance(playerMovement.transform.position, lastEndPosition) < playerDistanceSpawnLevelPart)
        {
            //Spawn another level part
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        CorridorPool choosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(choosenLevelPart.Get() ,lastEndPosition); // Get the spwan level
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelpartTransform = levelPart;
        levelpartTransform.position = spawnPosition;
        levelpartTransform.gameObject.SetActive(true);
        return levelpartTransform;
    }
}
