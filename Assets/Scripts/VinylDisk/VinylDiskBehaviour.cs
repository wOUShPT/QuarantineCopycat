using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VinylDiskBehaviour : MonoBehaviour
{
    private bool wasInterected = false;
    [Range(0.001f, 1f)]
    [SerializeField]private float volumeChange = 0.002f;
    [SerializeField]private AudioSource audioSourceReference;
    public AudioSource AudiouSourceReference => audioSourceReference;
    private void Awake()
    {
        
        audioSourceReference = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (audioSourceReference.isPlaying)
        {
            if (InputManager.Instance.PlayerInput.SwitchTvVolume < 0)
            {
                audioSourceReference.volume -= volumeChange;
            }
            if (InputManager.Instance.PlayerInput.SwitchTvVolume > 0)
            {
                audioSourceReference.volume += volumeChange;
            }
        }
    }

    public void ExitInteraction()
    {
        if (wasInterected)
        {
            wasInterected = false;
        }
    }
    public void PlayVinylDisk(AudioClip _audioclip)
    {
        Debug.Log(_audioclip);
        Debug.Log(audioSourceReference);
        audioSourceReference.clip = _audioclip;
        audioSourceReference.Play();
        Debug.Log("Play");
    }
    public void StopVinylDisk()
    {
        //Stop audiosource
        audioSourceReference.Stop();
        audioSourceReference.clip = null;
        Debug.Log("Stop");
    }
}
