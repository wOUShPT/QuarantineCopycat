using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Animator transitionAnimator;
    private bool _canTransitionNextScene;
    [SerializeField] private LoadingScreen loadingScreen;
    
    

    void Awake()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Day1");
        asyncLoad.allowSceneActivation = false;
        loadingScreen.gameObject.SetActive(true);
        while (asyncLoad.progress < 0.9f)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            loadingScreen.currentProgress = asyncLoad.progress/0.9f;
            yield return null;
        }
        loadingScreen.currentProgress = asyncLoad.progress/0.9f;
        yield return new WaitForSeconds(0.5f);
        loadingScreen.TransitionAnimation();
        yield return new WaitForSeconds(1.5f);
        asyncLoad.allowSceneActivation = true;
    }

    public void TransitionToNewGame()
    {
        _canTransitionNextScene = true;
    }
    
}
