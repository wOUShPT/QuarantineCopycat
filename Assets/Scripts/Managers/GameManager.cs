using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    private int _currentDayIndex;
    [SerializeField]
    private List<GameEvent> _goalsEntryList;
    private Queue<GameEvent> _goalsQueue;

    [SerializeField]
    private PlayableDirector _eventsSequence;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _goalsQueue = new Queue<GameEvent>();
        foreach (var goal in _goalsEntryList)
        {
            _goalsQueue.Enqueue(goal);
        }
        TimelineManager.Instance.Init(_eventsSequence);

        _currentDayIndex = 1;
        ChangeDay();
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

    public void Progress(GameEvent currentEvent)
    {
        switch (CurrentDay)
        {
            case 1:

                if (currentEvent == _goalsQueue.Peek())
                {
                    Debug.Log(currentEvent);
                    _goalsQueue.Dequeue();
                    TimelineManager.Instance.Resume(_eventsSequence);
                }
                break;
            
            case 2:

                break;
            
            case 3:

                break;
            
            case 4:

                break;
            
            case 5:

                break;
            
            case 6:

                break;
            
            case 7:

                break;
        }
    }

    
    //Change level properties based on the current day index
    public void ChangeDay()
    {
        switch (CurrentDay)
        {
            case 1:

                break;
            
            case 2:

                break;
            
            case 3:

                break;
            
            case 4:

                break;
            
            case 5:

                break;
            
            case 6:

                break;
            
            case 7:

                break;
        }
    }
        
}
