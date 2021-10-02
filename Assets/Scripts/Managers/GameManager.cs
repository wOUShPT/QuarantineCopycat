using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int currentDay;
    void Awake()
    {
        currentDay = 0;
    }
    
    void Update()
    {
        
    }

    public int CurrentDay
    {
        get => currentDay;
        set
        {
            if (value <= 7)
            {
                currentDay = value;
            }
        }
    }
}
