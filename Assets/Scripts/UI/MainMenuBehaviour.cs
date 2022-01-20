using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;

    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void StartNewMainGame()
    {
        StartCoroutine(TransitionToNewScene());
    }
    public void ExitGame() //Quit game
    {
        Application.Quit();
    }
    public void DisableCanvasGroup(CanvasGroup _canvasGroup)
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
    public void EnableCanvasGroup(CanvasGroup _canvasGroup)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }

    IEnumerator TransitionToNewScene()
    {
        transitionAnimator.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
    
}
