using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class FMODSnapshotLoader : MonoBehaviour
{
    [SerializeField] private EventReference snapshot;
    private EventInstance _instance;

    private void Awake()
    {
        if (snapshot.IsNull)
        {
            return;
        }
        _instance = RuntimeManager.CreateInstance(snapshot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !snapshot.IsNull)
        {
            _instance.start();
            Debug.Log("Changed snapshot to: " + snapshot.Path);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !snapshot.IsNull)
        {
            _instance.stop(STOP_MODE.IMMEDIATE);
        }
    }
}
