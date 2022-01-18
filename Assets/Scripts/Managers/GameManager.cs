using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    private int _currentDayIndex;
    [SerializeField] 
    private UnityEvent preEffect;
    [SerializeField]
    private List<Goal> _goalsEntryList;
    private Queue<Goal> _goalsQueue;
    [SerializeField]
    private PlayableDirector _eventsSequence;
    private List<bool> _currentGoalsMet;
    private bool _canProgress;
    private int _goalsMetCounter;


    [Serializable]
    private class Goal
    {
        public List<GameEvent> goalEvents;
        public List<bool> goalsMet;
        public float effectDelay;
        public UnityEvent effect;
    }
    
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _goalsQueue = new Queue<Goal>();
        foreach (var goal in _goalsEntryList)
        {
            _goalsQueue.Enqueue(goal);
        }
        
        //TimelineManager.Instance.Init(_eventsSequence);
        //TimelineManager.Instance.DelayedResume(_eventsSequence, 2);
        
        _currentDayIndex = 1;
        _goalsMetCounter = 0;
        _canProgress = false;
        preEffect.Invoke();
    }

    // CurrentDay index property
    public int CurrentDay
    {
        get => _currentDayIndex;
        set
        {
            if (value <= 7 && value > 0)
            {
                _currentDayIndex = value;
            }
            else
            {
                #if UNITY_EDITOR
                EditorApplication.isPaused = true;
                Debug.Log("<color=red>CurrentDay was set to an invalid number</color>");
                #endif
            }
        }
    }

    
    //Play Sequence/CutScene method
    public void StartSequence(PlayableDirector sequence)
    {
        sequence.Play();
    }

    
    //Increment Day Index
    public void IncrementDayCounter()
    {
        CurrentDay++;
    }

    public void Progress(GameEvent currentGoal)
    {
        for (int i = 0; i < _goalsQueue.Peek().goalEvents.Count; i++)
        {
            if (currentGoal == _goalsQueue.Peek().goalEvents[i])
            {
                _goalsQueue.Peek().goalsMet[i] = true;
                _goalsMetCounter++;
                if (_goalsMetCounter == _goalsQueue.Peek().goalEvents.Count)
                {
                    _goalsMetCounter = 0;
                    _canProgress = false;
                    _goalsQueue.Peek().effect.Invoke();
                    _goalsQueue.Dequeue();
                }
            }
        }
    }

    private IEnumerator StartEvent(UnityEvent currentEvent, float delay)
    {
        yield return new WaitForSeconds(delay);
        currentEvent.Invoke();
    }
}
