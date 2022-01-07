using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class TelevisionBehaviour : MonoBehaviour
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
    [FormerlySerializedAs("clips")] [SerializeField]
    private VideoClip[] manualVideos;
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
    private double _currentscriptedClipTotalTime;
    private double _currentScriptedClipTimeElapsed;
    private int _loopCounter;
    private float _zappingTimer;
    private float _zappingTimeInterval;
    private bool _isOn;

    [Serializable]
    public class ScriptedVideoClass
    {
        public VideoClip clip;
        public bool isLooping;
        public int numberOfLoops;
    }
    

    private void Start()
    {
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
        _videoPlayer.clip = manualVideos[_currentManualClipIndex];
        _videoPlayer.time = _manualClipsTotalTime[_currentManualClipIndex];
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
            _manualClipsTimeElapsed[i] = manualVideos[i].frameCount;
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
        _currentScriptedClipTimeElapsed = 0;
        _currentscriptedClipTotalTime = scriptedVideos[_currentScriptedClipIndex].clip.length;
        _videoPlayer.clip = scriptedVideos[_currentScriptedClipIndex].clip;
        _videoPlayer.time = 0;
    }
    
    public void ToggleTvPower()
    {
        _isOn = !_isOn;
        
        if (_isOn)
        {
            screenMesh.material = _onMaterial;
            _videoPlayer.Play();
            if(mode == TVMode.Manual)
            {
                SwitchChannel();
                _zappingTimer = _zappingTimeInterval;
            }


        }
        else
        {
            _videoPlayer.Stop();
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
    }

   /*IEnumerator PowerOn()
    {
        screenMesh.material = _onMaterial;
        float colorValue = 0;
        _onMpb.SetColor("_BaseColor", new Color(colorValue, colorValue, colorValue, 1));
        screenMesh.SetPropertyBlock(_onMpb);
        while (colorValue != 255)
        {
            colorValue = (int)Mathf.Lerp(colorValue, 255, 50*Time.deltaTime);
            _onMpb.SetColor("_BaseColor", new Color(colorValue, colorValue, colorValue, 1));
            _onMaterial.SetColor();
            yield return null;
        }
    }
    
    IEnumerator PowerOff()
    {
        float colorValue = 255;
        _offMpb.SetColor("_BaseColor", new Color(colorValue, colorValue, colorValue, 1));
        while (colorValue != 0)
        {
            colorValue = (int)Mathf.Lerp(colorValue, 0, 50*Time.deltaTime);
            _onMpb.SetColor("_BaseColor", new Color(colorValue, colorValue, colorValue, 1));
            yield return null;
        }

        screenMesh.material = _offMaterial;
    }*/
}
