using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VinylDiskBehaviour : MonoBehaviour
{
    private bool wasInterected = false;
    [Range(0.001f, 1f)]
    [SerializeField]private float volumeChange = 0.002f;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClipArray;
    private int currentAudioClip = 0;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClipArray[currentAudioClip];
    }
    private void Update()
    {
        if (audioSource.isPlaying)
        {
            if (InputManager.Instance.PlayerInput.SwitchTvVolume < 0)
            {
                audioSource.volume -= volumeChange;
            }
            if (InputManager.Instance.PlayerInput.SwitchTvVolume > 0)
            {
                audioSource.volume += volumeChange;
            }
        }
    }

    public void ExitInteraction()
    {
        if (wasInterected)
        {
            wasInterected = false;
        }
        wasInterected = false;
    }
    public void PlayVinylDisk(AudioClip _audioclip)
    {
        audioSource.clip = _audioclip;
        audioSource.Play();
        Debug.Log("Play");
    }
    public void StopVinylDisk()
    {
        //Stop audiosource
        audioSource.Stop();
        audioSource.clip = null;
        Debug.Log("Stop");
    }
}
