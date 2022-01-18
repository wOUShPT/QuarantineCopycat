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
    [SerializeField]
    private Animator _animator;
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
        audioSourceReference.clip = _audioclip;
        audioSourceReference.Play();
        _animator.Play("VinylRotation");
    }
    public void StopVinylDisk()
    {
        //Stop audiosource
        audioSourceReference.Stop();
        audioSourceReference.clip = null;
        _animator.StopPlayback();
    }
}
