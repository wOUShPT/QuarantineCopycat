using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using UnityEngine;
using FMOD.Studio;

public class VinylDiskBehaviour : InteractableBehaviour
{
    [SerializeField] private ItemType _item;
    private bool _wasInteracted;
    [Range(0.001f, 1f)]
    [SerializeField] private float _volumeIncrement = 0.002f;
    [SerializeField] private Animator _animator;
    private FMOD.Studio.EventInstance _music;
    protected override void Awake()
    {
        base.Awake();
        /*_music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Diagetic/Vinyl2");
        _music.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _music.release();*/
    }

    public void Start()
    {
        _wasInteracted = false;
    }

    private void Update()
    {
        if (_wasInteracted)
        {
            if (InputManager.Instance.PlayerInput.SwitchTvVolume < 0)
            {
                _music.getVolume(out float currentVolume);
                _music.setVolume(currentVolume - _volumeIncrement);
            }
            if (InputManager.Instance.PlayerInput.SwitchTvVolume > 0)
            {
                _music.getVolume(out float currentVolume);
                _music.setVolume(currentVolume + _volumeIncrement);
            }
        }
        else
        {
            _animator.StopPlayback();
        }
    }

    public override void Interact()
    {
        PlayVinylDisk();
    }

    public void PlayVinylDisk()
    {
        _music.start();
        _animator.Play("VinylRotation");
    }
    public void StopVinylDisk()
    {
        //Stop audiosource
        _music.stop(STOP_MODE.IMMEDIATE);
        _animator.StopPlayback();
    }

    public void OnDestroy()
    {
        _music.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
