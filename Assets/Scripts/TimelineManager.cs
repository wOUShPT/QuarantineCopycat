using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class TimelineManager : Singleton<TimelineManager>
{
    private float _currentPlayableAssetDuration;
    private int currentInputIndex;
    private float currentClipDuration;

    public void Skip(PlayableDirector director)
    {
        
    }

    public void Init(PlayableDirector director)
    {
        director.Play();
        Pause(director);
    }

    public void Resume(PlayableDirector director)
    {
        director.time = director.time;
        UIManager.Instance.ToggleSubtitle(false);
        Debug.Log("Timeline resumed");
        director.playableGraph.GetRootPlayable(0).SetSpeed(1d);
    }

    public void Pause(PlayableDirector director)
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(0d);
    }

    public void DelayedResume(PlayableDirector director, float seconds)
    {
        StartCoroutine(DelayResumeCoroutine(director, seconds));
    }

    IEnumerator DelayResumeCoroutine(PlayableDirector director, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Resume(director);
        
    }
}
