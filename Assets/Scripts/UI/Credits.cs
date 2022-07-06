using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public List<Animator> creditsBlocks;
    public Animator thanksBlock;
    public float blockDuration;

    private void Awake()
    {
        foreach (var block in creditsBlocks)
        {
            block.gameObject.SetActive(false);
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        foreach (var block in creditsBlocks)
        {
            block.gameObject.SetActive(true);
            block.speed = 1 / blockDuration;
            yield return new WaitForSeconds(blockDuration);
            block.speed = 1;
            block.SetTrigger("FadeOut");
            yield return new WaitForSeconds(2f);
            block.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }
}
