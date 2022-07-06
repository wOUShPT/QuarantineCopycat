using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public CanvasGroup reticle;
    public CanvasGroup mouseHint;
    private Animator _mouseHintAnimator;
    public CanvasGroup crosshair;
    public CanvasGroup interactionPrompt;
    public Subtitle subtitle;
    public UI_Inventory _uiInventory;
    public GameObject phoneHint;

    private void Awake()
    {
        _mouseHintAnimator = mouseHint.GetComponent<Animator>();
        if (phoneHint != null)
        {
            phoneHint.SetActive(false);
        }
        
    }
    

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
    
    public void ToggleMouseHint(bool state)
    {
        if (state)
        {
            if (mouseHint.alpha == 0)
            {
                _mouseHintAnimator.Rebind();
                _mouseHintAnimator.Update(0);
            }
            mouseHint.alpha = 1;
        }
        else
        {
            mouseHint.alpha = 0;
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

    public void ToggleSubtitle(bool state)
    {
        if (state)
        {
            subtitle.canvasGroup.alpha = 1;
        }
        else
        {
            subtitle.canvasGroup.alpha = 0;
        }
    }

    public void EnablePhoneHint()
    {
        phoneHint.SetActive(true);
    }

    public void SetSubtitle(string charName, string lineOfDialogue, int sizeOfDialogue)
    {
        subtitle.text.SetText(lineOfDialogue);
        ToggleSubtitle(true);
    }

    [Serializable]
    public class Subtitle
    {
        public TextMeshProUGUI text;
        public CanvasGroup canvasGroup;
    }
}


