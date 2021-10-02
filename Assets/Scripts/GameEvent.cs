using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> _eventListeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = _eventListeners.Count - 1; i >= 0; i--)
        {
            _eventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener eventListener)
    {
        if (!_eventListeners.Contains(eventListener))
        {
            _eventListeners.Add(eventListener);
        }
    }

    public void UnregisterListener(GameEventListener eventListener)
    {
        if (_eventListeners.Contains(eventListener))
        {
            _eventListeners.Remove(eventListener);
        }
    }
}
