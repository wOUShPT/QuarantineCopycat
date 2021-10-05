using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    private int currentDayIndex;
    public AnimatorReferences animatorReferences;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentDayIndex = 1;
        ChangeDay();
    }

    // CurrentDay index property
    public int CurrentDay
    {
        get => currentDayIndex;
        set
        {
            if (value <= 7 && value > 0)
            {
                currentDayIndex = value;
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
