using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActivator : MonoBehaviour
{
    private bool _isPaused;
    public PauseMenu pauseMenu;

    private void Awake()
    {
        _isPaused = false;
        StartCoroutine(CheckInput());
    }

    private IEnumerator CheckInput()
    {
        while (true)
        {
            if(InputManager.Instance.PlayerInput.Pause > 0)
            {
                if (_isPaused)
                {
                    Resume();
                    yield return new WaitForSecondsRealtime(0.1f);
                }
                else
                {
                    Pause();
                    yield return new WaitForSecondsRealtime(0.1f);
                }
            }
            yield return null;
        }
    }


    public void Pause()
    {
        _isPaused = true;
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        _isPaused = false;
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
        
}
