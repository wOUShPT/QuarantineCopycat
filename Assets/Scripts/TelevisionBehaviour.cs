using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class TelevisionBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameEvent _gameEvent;
    private TVMode mode;
    private enum TVMode
    {
        Manual, Cycle
    }
    private VideoPlayer _videoPlayer;
    [SerializeField]
    private VideoClip[] clips;
    [SerializeField] 
    private MeshRenderer screenMesh;
    [SerializeField]
    private Material _onMaterial;
    [SerializeField]
    private Material _offMaterial;
    private MaterialPropertyBlock _onMpb;
    private MaterialPropertyBlock _offMpb;
    private int _currentClipIndex;
    private double[] _clipsTotalTime;
    private double[] _clipsCurrentTime;
    private float _zappingTimer;
    private float _zappingTimeInterval;
    private bool _isOn;
    

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _clipsTotalTime = new double[clips.Length];
        _clipsCurrentTime = new double[clips.Length];

        for (int i = 0; i < clips.Length; i++)
        {
            _clipsTotalTime[i] = clips[i].length;
            _clipsCurrentTime[i] = 0;
        }

        _currentClipIndex = 0;
        _zappingTimeInterval = 1;
        _zappingTimer = _zappingTimeInterval;
        _isOn = false;
        ToggleTvPower();
        ToggleTvPower();
    }

    private void Update()
    {
        _zappingTimer += Time.deltaTime;
        _zappingTimer = Mathf.Clamp(_zappingTimer, 0,_zappingTimeInterval);

        if (_isOn)
        {
            if (InputManager.Instance.PlayerInput.Movement.z > 0)
            {
                Debug.Log("Raised");
                _gameEvent.Raise();
            }
        }
            
        
        if (_videoPlayer.isPlaying)
        {
            if (_zappingTimer >= _zappingTimeInterval)
            {
                if (InputManager.Instance.PlayerInput.SwitchTvChannel < 0)
                {
                    _currentClipIndex--;
                    if (_currentClipIndex < 0)
                    {
                        _currentClipIndex = clips.Length - 1;
                    }
                
                    _zappingTimer = 0;
                    SwitchChannel();
                }

                if (InputManager.Instance.PlayerInput.SwitchTvChannel > 0)
                {
                    _currentClipIndex++;
                    if (_currentClipIndex == clips.Length) 
                    { 
                        _currentClipIndex = 0;
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
    }

    private void SwitchChannel()
    {
        _videoPlayer.clip = clips[_currentClipIndex];
        _videoPlayer.time = _clipsCurrentTime[_currentClipIndex];
        _videoPlayer.Play();
    }


    private void UpdateChannelsTime()
    {
        for (int i = 0; i < _clipsCurrentTime.Length; i++)
        {
            _clipsCurrentTime[i] = Mathf.Repeat((float)(_clipsCurrentTime[i] + Time.deltaTime), (float)_clipsTotalTime[i]);
            //Debug.Log(clips[i] + " : " + _clipsCurrentTime[i]);
        }
    }

    public void ToggleTvPower()
    {
        _isOn = !_isOn;
        
        if (_isOn)
        {
            screenMesh.material = _onMaterial;
            _videoPlayer.Play();
            SwitchChannel();
            _zappingTimer = _zappingTimeInterval;

        }
        else
        {
            _videoPlayer.Stop();
            screenMesh.material = _offMaterial;
        }
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
