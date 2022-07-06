using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScreenPress : MonoBehaviour
{
    public CanvasGroup mainMenuCanvasGroup;
    
    public void EnableMainMenu()
    {
        StartCoroutine(EnableMainMenuAnimation());
    }

    IEnumerator EnableMainMenuAnimation()
    {
        while (mainMenuCanvasGroup.alpha != 1)
        {
            mainMenuCanvasGroup.alpha = Mathf.MoveTowards(mainMenuCanvasGroup.alpha, 1, 2 * Time.deltaTime);
            yield return null;
        }
        mainMenuCanvasGroup.interactable = true;
        mainMenuCanvasGroup.blocksRaycasts = true;
    }
}


