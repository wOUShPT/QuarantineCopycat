using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class SubtitleBehaviour : PlayableBehaviour
{
    public string characterName;
    public string dialogueLine;
    private int dialogueSize;

    public bool pauseWhenDone = false;

    private bool _clipPlayed = false;
    private bool _pauseScheduled = false;
    private PlayableDirector director;

    public override void OnPlayableCreate(Playable playable)
    {
        director = (playable.GetGraph().GetResolver() as PlayableDirector);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if(!_clipPlayed && info.weight > 0f)
        {
            UIManager.Instance.SetSubtitle(characterName, dialogueLine, dialogueSize);

            if(Application.isPlaying)
            {
                if(pauseWhenDone)
                {
                    _pauseScheduled = true;
                }
            }
            
            _clipPlayed = true;
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (UIManager.Instance == null)
        {
            return;
        }
        if(_pauseScheduled)
        {
            _pauseScheduled = false;
            TimelineManager.Instance.Pause(director);
        }
        else
        {
            UIManager.Instance.ToggleSubtitle(false);
        }
        
        _clipPlayed = false;
    }
}
