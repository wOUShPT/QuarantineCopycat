using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[RequireComponent(typeof(PlayableDirector))]
public class TimelineController : MonoBehaviour
{
    [SerializeField] 
    private List<GameEvent> conditions;
    [SerializeField]
    PlayableDirector _playableDirector;
    private float _currentPlayableAssetDuration;

    private float _timer;
    void Start()
    {
        _playableDirector.Stop();
        _playableDirector.extrapolationMode = DirectorWrapMode.Hold;
    }

    public void NextEvent()
    {
        _playableDirector.Resume();
    }
}
