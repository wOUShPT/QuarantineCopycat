using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogueMarker : Marker, INotification, INotificationOptionProvider
{
    [SerializeField] 
    private string message = "";
    [SerializeField] 
    private string speakerName = "";

    [Space(20)] 
    [SerializeField] 
    private bool retroactive = false;
    [SerializeField]
    private bool emitOnce = false;
    
    

    public PropertyName id => new PropertyName();
    public string Message => message;
    public string SpeakerName => speakerName;

    public NotificationFlags flags => (retroactive ? NotificationFlags.Retroactive : default) | (emitOnce ? NotificationFlags.TriggerOnce : default);
}
