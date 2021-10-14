using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDReferences : MonoBehaviour
{
    public CanvasGroup reticle;
    public CanvasGroup crosshair;
    public CanvasGroup interactionPrompt;


    public void ToggleInteractionPrompt(bool state)
    {
        if (state)
        {
            interactionPrompt.alpha = 1;
        }
        else
        {
            interactionPrompt.alpha = 0;
        }
    }
    
    public void ToggleReticle(bool state)
    {
        if (state)
        {
            reticle.alpha = 1;
        }
        else
        {
            reticle.alpha = 0;
        }
    }
    
    public void ToggleCrosshair(bool state)
    {
        if (state)
        {
            crosshair.alpha = 1;
        }
        else
        {
            crosshair.alpha = 0;
        }
    }
}


