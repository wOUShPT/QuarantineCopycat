using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DebugCanvas : MonoBehaviour
{
    [SerializeField]
    private DebugStat _freezeMovement;
    [SerializeField] 
    private DebugStat _freezeAim;
    [SerializeField] 
    private DebugStat _freezeInteraction;
    [SerializeField] 
    private DebugStat _CameraMode;

#if UNITY_EDITOR

    
    void Awake()
    {
        _freezeMovement.gameObject.SetActive(true);
        _freezeAim.gameObject.SetActive(true);
        _freezeInteraction.gameObject.SetActive(true);
    }


    
    void Update()
    {
        _freezeMovement.statTMP.text = $"Freeze Movement : {PlayerProperties.FreezeMovement}";
        _freezeAim.statTMP.text = $"Freeze Aim : {PlayerProperties.FreezeAim}";
        _freezeInteraction.statTMP.text = $"Freeze Interaction : {PlayerProperties.FreezeInteraction}";
        _CameraMode.statTMP.text = $"Camera Mode : {PlayerProperties.Mode}";
    }
    
#endif
    
}
