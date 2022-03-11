using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using UnityEngine.Video;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class TelevisionBehaviour : InteractableBehaviour
{
    [FormerlySerializedAs("_gameEvent")] [SerializeField]
    private GameEvent _sofaOutGameEvent;
    [SerializeField]
    private TVMode mode;
    private enum TVMode
    {
        Manual, Scripted
    }
    private VideoPlayer _videoPlayer;
    [SerializeField]
    private ManualVideoClass[] manualVideos;
    [SerializeField]
    private ScriptedVideoClass[] scriptedVideos;
    [SerializeField] 
    private MeshRenderer screenMesh;
    [SerializeField]
    private Material _onMaterial;
    [SerializeField]
    private Material _offMaterial;
    private MaterialPropertyBlock _onMpb;
    private MaterialPropertyBlock _offMpb;
    private int _currentManualClipIndex;
    private int _currentScriptedClipIndex;
    private double[] _manualClipsTimeElapsed;
    private double[] _manualClipsTotalTime;
    private int _loopCounter;
    private float _zappingTimer;
    private float _zappingTimeInterval;
    private bool _isOn;
    private FMOD.Studio.EventInstance _fmodInstance;
    [SerializeField] private UnityEvent preEffect;
    [SerializeField] private UnityEvent effect;
    [Serializable]
    public class ScriptedVideoClass
    {
        public VideoClip clip;
        public EventReference FMODEvent;
        public bool isLooping;
        public int numberOfLoops;
    }

    [Serializable]
    public class ManualVideoClass
    {
        public VideoClip clip;
        public EventReference FMODEvent;
    }
    
    private bool _wasInteracted;
    

    private void Start()
    {
        _wasInteracted = false;
        //DisableInteraction();
        _videoPlayer = GetComponent<VideoPlayer>();

        if (mode == TVMode.Manual)
        {
            InitManualTv();
        }
        else
        {
            InitScriptedTv();
        }
    }

    public override void Interact()
    {
        if (!_wasInteracted && CanInteract)
        {
            DisableInteraction();
            ToggleTvPower(); 
        }
    }

    private void Update()
    {
        switch (mode)
        {
            case TVMode.Manual:
                
                _zappingTimer += Time.deltaTime;
                _zappingTimer = Mathf.Clamp(_zappingTimer, 0,_zappingTimeInterval);

                if (_isOn)
                {
                    if (InputManager.Instance.PlayerInput.Movement.z > 0)
                    {
                        _sofaOutGameEvent.Raise();
                    }
                }
                
                if (_videoPlayer.isPlaying)
                {
                    if (_zappingTimer >= _zappingTimeInterval && manualVideos.Length > 1)
                    {
                        if (InputManager.Instance.PlayerInput.SwitchTvChannel < 0)
                        {
                            _currentManualClipIndex--;
                            if (_currentManualClipIndex < 0)
                            {
                                _currentManualClipIndex = manualVideos.Length - 1;
                            }
                            _zappingTimer = 0;
                            SwitchChannel();
                        }

                        if (InputManager.Instance.PlayerInput.SwitchTvChannel > 0)
                        {
                            _currentManualClipIndex++;
                            if (_currentManualClipIndex == manualVideos.Length) 
                            { 
                                _currentManualClipIndex = 0;
                            }
                            _zappingTimer = 0; 
                            SwitchChannel();
                        }
                    }
            
                    if (InputManager.Instance.PlayerInput.SwitchTvVolume < 0)
                    {
                        _videoPlayer.GetTargetAudioSource(0).volume -= 0.002f;
                    }

                    if (InputManager.Instance.PlayerInput.SwitchTvVolume > 0)
                    {
                        _videoPlayer.GetTargetAudioSource(0).volume += 0.002f;
                    }
                }

                UpdateChannelsTime();
                
                break;
        }
    }

    // Switch the channel
    private void SwitchChannel()
    {
        _videoPlayer.clip = manualVideos[_currentManualClipIndex].clip;
        _videoPlayer.time = _manualClipsTotalTime[_currentManualClipIndex];
        _fmodInstance.stop(STOP_MODE.IMMEDIATE);
        _fmodInstance = RuntimeManager.CreateInstance(manualVideos[_currentManualClipIndex].FMODEvent);
        _fmodInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        _fmodInstance.start();
        _videoPlayer.Play();
    }


    // Keep track of programs timestamp on manual mode
    private void UpdateChannelsTime()
    {
        if (mode == TVMode.Manual)
        {
            for (int i = 0; i < _manualClipsTotalTime.Length; i++)
            {
                _manualClipsTotalTime[i] = Mathf.Repeat((float)(_manualClipsTotalTime[i] + Time.deltaTime), (float)_manualClipsTimeElapsed[i]);
            }
        }
    }


    public void InitManualTv()
    {
        _manualClipsTimeElapsed = new double[manualVideos.Length];
        _manualClipsTotalTime = new double[manualVideos.Length];

        for (int i = 0; i < manualVideos.Length; i++)
        {
            _manualClipsTimeElapsed[i] = manualVideos[i].clip.frameCount;
            _manualClipsTotalTime[i] = 0;
        }

        _currentManualClipIndex = 0;
        _zappingTimeInterval = 1;
        _zappingTimer = _zappingTimeInterval;
        _isOn = false;
        ToggleTvPower();
        ToggleTvPower();
    }

    public void InitScriptedTv()
    {
        _isOn = false;
        _videoPlayer.loopPointReached += HandleLoopCount;
        _currentScriptedClipIndex = 0;
        _fmodInstance = RuntimeManager.CreateInstance(scriptedVideos[_currentScriptedClipIndex].FMODEvent);
        _fmodInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        _videoPlayer.clip = scriptedVideos[_currentScriptedClipIndex].clip;
        _videoPlayer.time = 0;
    }
    
    public void ToggleTvPower()
    {
        _isOn = !_isOn;
        
        if (_isOn)
        {
            if (!_wasInteracted)
            {
                preEffect.Invoke();
                _wasInteracted = true;
            }
            screenMesh.material = _onMaterial;
            _fmodInstance.start();
            _videoPlayer.Play();
            if(mode == TVMode.Manual)
            {
                SwitchChannel();
                _zappingTimer = _zappingTimeInterval;
            }
        }
        else
        {
            effect.Invoke();
            _videoPlayer.Stop();
            _fmodInstance.stop(STOP_MODE.IMMEDIATE);
            screenMesh.material = _offMaterial;
        }
    }


    // Handle the videoclips loop count, called on the end of a loop
    private void HandleLoopCount(VideoPlayer vp)
    {
        if (_currentScriptedClipIndex == scriptedVideos.Length - 1)
        {
            _sofaOutGameEvent.Raise();
            return;
        }
        
        if (_loopCounter == scriptedVideos[_currentScriptedClipIndex].numberOfLoops)
        {
            _loopCounter = 0;
            SkipToNextVideo();
            Debug.Log("Video skiped");
        }
        _loopCounter++;
        Mathf.Clamp(_loopCounter, 0, scriptedVideos[_currentScriptedClipIndex].numberOfLoops);
    }

    //skip to the next video clip
    private void SkipToNextVideo()
    {
        _currentScriptedClipIndex++;
        _videoPlayer.clip = scriptedVideos[_currentScriptedClipIndex].clip;
        _videoPlayer.Play();
        _fmodInstance.stop(STOP_MODE.IMMEDIATE);
        _fmodInstance = RuntimeManager.CreateInstance(scriptedVideos[_currentScriptedClipIndex].FMODEvent);
        _fmodInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        _fmodInstance.start();
    }
}
