using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueReceiver : MonoBehaviour, INotificationReceiver
{
    [SerializeField] private DialogueAnimationHandler _dialogueAnimationHandler;
    
    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is DialogueMarker dialogueMarker && _dialogueAnimationHandler != null)
        {
            var newDialogue = new Dialogue
            {
                Message = dialogueMarker.Message,
                SpeakerName = dialogueMarker.SpeakerName,
            };
            
        }
    }
}


