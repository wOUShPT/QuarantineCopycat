using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CorridorGenerator : MonoBehaviour
{
    
    [SerializeField] private float playerDistanceSpawnLevelPart = 20f;
    
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private  Corridor[] corridorPoolArray;
    [System.Serializable]
    struct Corridor //Details abou the pools
    {
        public string name;
        public CorridorPool corridorPart;
    }
    enum CorridorType
    {
        Straight, CurveRightEnd, CurveLeftEnd
    }
    class PlacedCorridorInformation
    {
        public CorridorInfo corridorInfo;
        public PlacedCorridorInformation(CorridorInfo _corridorInfo) //Constructor to have the informations
        {
            corridorInfo = _corridorInfo;
        }
    }
    //Check all corridor active
    private List<PlacedCorridorInformation> corridorInformationList; 
    private Transform lastEndPositionTransform;

    private CharacterController playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<CharacterController>();
        lastEndPositionTransform = levelPartStart.Find("EndPosition");
        corridorInformationList = new List<PlacedCorridorInformation>();
    }
    private void Update()
    {
        if (Vector3.Distance(playerMovement.transform.position, lastEndPositionTransform.position) < playerDistanceSpawnLevelPart)
        {
            //Spawn another level part
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        CorridorInfo choosenLevelPart = corridorPoolArray[Random.Range(0, corridorPoolArray.Length)].corridorPart.Get();
        Transform lastLevelPartTransform = SpawnLevelPart(choosenLevelPart ,lastEndPositionTransform.position); // Get the spwan level
        TurnOffCorridor(choosenLevelPart);
        corridorInformationList.Add(new PlacedCorridorInformation(choosenLevelPart));
        lastEndPositionTransform = lastLevelPartTransform.Find("EndPosition");
    }
    private Transform SpawnLevelPart(CorridorInfo levelPart, Vector3 spawnPosition)
    {
        Transform levelpartTransform = levelPart.transform;
        levelpartTransform.position = spawnPosition;
        levelpartTransform.rotation = lastEndPositionTransform.rotation;
        levelpartTransform.gameObject.SetActive(true);
        return levelpartTransform;
    }

    private void TurnOffCorridor(CorridorInfo currentCorridor)
    {
        if(/*currentCorridor.GetCorridorType() == CorridorInfo.CorridorType.RightCurve*/ corridorInformationList.Count >= 5)
        {
            //Return to the pool
            CorridorInfo corridorInformation = corridorInformationList[0].corridorInfo;
            corridorInformationList.RemoveAt(0);
            corridorPoolArray[0].corridorPart.ReturnToPool(corridorInformation);
        }
    }

}
