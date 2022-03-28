using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class FMODEventSource : MonoBehaviour
{
   public EventReference FMODEvent;
   public GameObject sourceGameObject;
   private EventInstance _eventInstance;

   public void Start()
   {
      _eventInstance = FMODUnity.RuntimeManager.CreateInstance(FMODEvent);
      _eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(sourceGameObject));
   }

   public void PlayEvent()
   {
      _eventInstance.start();
   }

   public void OnDestroy()
   {
      _eventInstance.stop(STOP_MODE.ALLOWFADEOUT);
   }
}
