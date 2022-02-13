using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class DialogueAnimationHandler : MonoBehaviour
{
    [SerializeField]
    private float transitionDuration;
    
    public void AddDialogue(Dialogue dialogue)
    {
        if (UIManager.Instance.subtitle.text != null || UIManager.Instance.subtitle.canvasGroup != null)
        {
            
        }
    }

    IEnumerator TransitionCoroutine()
    {
        if (UIManager.Instance.subtitle.canvasGroup.alpha == 0)
        {
            UIManager.Instance.subtitle.canvasGroup.alpha += 1 / transitionDuration * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    
}

public struct Dialogue
{
    public string Message;
    public string SpeakerName;
    public TrackAsset ParentTrack;
}
