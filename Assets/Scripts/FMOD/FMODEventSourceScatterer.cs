using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class FMODEventSourceScatterer : MonoBehaviour
{
      [HideInInspector] public int currentTypeIndex = 0;
       public EventReference FMODEvent;
       public GameObject[] sourceObjects;
       private EventInstance _eventInstance;
    
       public void Start()
       {
          if (FMODEvent.IsNull)
          {
             return;
          }
          _eventInstance = FMODUnity.RuntimeManager.CreateInstance(FMODEvent);
          StartCoroutine(Scatter());
       }

       private IEnumerator Scatter()
       {
          _eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(sourceObjects[Random.Range(0, sourceObjects.Length - 1)]));
          _eventInstance.start();

          yield return new WaitForEndOfFrame();
          
          while (true)
          {
             _eventInstance.getPlaybackState(out PLAYBACK_STATE currentState);
             
             if (currentState == PLAYBACK_STATE.STOPPED)
             {
                Debug.Log("New Source");
                _eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(sourceObjects[Random.Range(0, sourceObjects.Length - 1)]));
                _eventInstance.start();
             }

             yield return null;
          }

          yield return null;
       }

       public void OnDestroy()
       {
          if (FMODEvent.IsNull)
          {
             return;
          }

          _eventInstance.stop(STOP_MODE.ALLOWFADEOUT);
       }
}
