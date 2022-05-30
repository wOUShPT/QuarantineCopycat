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
        StartCoroutine(TransitionReset(SceneManager.GetActiveScene().buildIndex));
    }
    public void ExitGame() //Quit game
    {
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        StartCoroutine(TransitionReset(0));
    }
    IEnumerator TransitionReset(int buildIndex)
    {
        transitionAnimator.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(buildIndex);
        yield return null;
    }
}
