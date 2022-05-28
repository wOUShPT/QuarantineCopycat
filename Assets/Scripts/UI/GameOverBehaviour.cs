using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBehaviour : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    // Start is called before the first frame update
    public void RestartLevel()
    {
        StartCoroutine(TransitionReset());
    }
    public void ExitGame() //Quit game
    {
        Application.Quit();
    }
    IEnumerator TransitionReset()
    {
        transitionAnimator.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }
}
