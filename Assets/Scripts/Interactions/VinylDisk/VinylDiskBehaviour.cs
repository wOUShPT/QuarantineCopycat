using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

[RequireComponent(typeof(Animator))]
public class VinylDiskBehaviour : InteractableBehaviour
{
    [SerializeField]
    private ItemType _triggerItem;
    private bool wasInteracted = false;
    [Range(0.001f, 1f)]
    [SerializeField]private float volumeIncrement = 0.002f;
    [SerializeField]
    private EventReference _FMODEvent;
    [SerializeField]
    private Animator _animator;
    [SerializeField] private GameObject diskGameObject;
    private FMOD.Studio.EventInstance _music;

    protected override void Awake()
    {
        base.Awake();
        DisableInteraction();

        _music = FMODUnity.RuntimeManager.CreateInstance(_FMODEvent);
        _music.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    private void Update()
    {
        if (wasInteracted)
        {
            if (InputManager.Instance.PlayerInput.SwitchTvVolume < 0)
            {
                _music.getVolume(out float currentVolume);
                _music.setVolume(Mathf.Clamp(currentVolume - volumeIncrement, 0f, 1f));
            }
            if (InputManager.Instance.PlayerInput.SwitchTvVolume > 0)
            {
                _music.getVolume(out float currentVolume);
                _music.setVolume(Mathf.Clamp(currentVolume + volumeIncrement, 0f, 1f));
            }
        }
        else
        {
            _animator.StopPlayback();
        }

        _music.getPlaybackState(out PLAYBACK_STATE currentPlaybackState);

        if (currentPlaybackState == PLAYBACK_STATE.STOPPED)
        {
            _animator.StopPlayback();
        }
    }

    public override void Interact()
    {
        if (InventoryManager.inventory.CheckHasItem(_triggerItem) && CanInteract)
        {
            InventoryManager.inventory.RemoveItem(_triggerItem);
            HideOutline();
            PlayVinylDisk();
            DisableInteraction();
        }
    }
    
    public void PlayVinylDisk()
    {
        wasInteracted = true;
        diskGameObject.SetActive(true);
        _music.start();
        _animator.Play("VinylRotation");
    }
    public void StopVinylDisk()
    {
        //Stop audiosource
        _music.stop(STOP_MODE.IMMEDIATE);
        _animator.StopPlayback();
    }

    private void OnDestroy()
    {
        _music.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
