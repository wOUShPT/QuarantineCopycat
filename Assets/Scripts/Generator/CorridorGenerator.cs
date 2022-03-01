using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    //Check all corridor active
    [SerializeField]private List<CorridorInfo> corridorInformationList; 
    private Transform lastEndPositionTransform;

    private CharacterController playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<CharacterController>();
        lastEndPositionTransform = levelPartStart.Find("EndPosition");
        foreach (CorridorInfo corridor in corridorInformationList)
        {
            corridor.gameObject.SetActive(true);
        }
        
    }
    private void Start()
    {
        UpdateLink();
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
        CorridorInfo lastPart = corridorInformationList[corridorInformationList.Count - 1];
        corridorInformationList.Add(choosenLevelPart);
        //lastPart.UpdateLink();
        lastEndPositionTransform = lastLevelPartTransform.Find("EndPosition");
        UpdateLink();
    }

    private Transform SpawnLevelPart(CorridorInfo levelPart, Vector3 spawnPosition)
    {
        Transform levelpartTransform = levelPart.transform;
        levelpartTransform.position = spawnPosition;
        levelpartTransform.rotation = lastEndPositionTransform.rotation;
        levelpartTransform.gameObject.SetActive(true);
        return levelpartTransform;
    }

    private void UpdateLink()
    {
        if (corridorInformationList.Count == 0)
            return;
        foreach (CorridorInfo placedCorridorInformation in corridorInformationList)
        {
            placedCorridorInformation.UpdateLink();
        }
    }

    private void TurnOffCorridor(CorridorInfo currentCorridor)
    {
        //if(/*currentCorridor.GetCorridorType() == CorridorInfo.CorridorType.RightCurve*/ corridorInformationList.Count >= 5)
        //{
        //    //Return to the pool
        //    CorridorInfo corridorInformation = corridorInformationList[0].corridorInfo;
        //    corridorInformationList.RemoveAt(0);
        //    corridorPoolArray[0].corridorPart.ReturnToPool(corridorInformation);
        //}
    }

}
