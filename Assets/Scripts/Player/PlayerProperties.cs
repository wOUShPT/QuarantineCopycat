using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static bool FreezeMovement = false;

    public static bool FreezeInteraction = false;

    public static bool FreezeAim = false;

    public static State Mode = State.Dynamic;

    public static void ToggleFreezeMovement(bool state)
    {
        FreezeMovement = state;
    }
    
    public static void ToggleFreezeInteraction(bool state)
    {
        FreezeInteraction = state;
    }

    public static void ToggleFreezeAim(bool state)
    {
        FreezeAim = state;
    }
    
    public void SwitchToCutsceneMode()
    {
        Mode = State.Cutscene;
    }

    public void SwitchToDynamicMode()
    {
        Mode = State.Dynamic;
    }

    public enum State
    {
        Dynamic,
        Cutscene
    }
}
