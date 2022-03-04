using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVinylBehaviour : MonoBehaviour, IInteractable
{
        private bool wasInterected = false;
        
        [Range(0.001f, 1f)]
        [SerializeField]private float volumeChange = 0.002f;
        [SerializeField]private AudioSource audioSourceReference;
        public AudioSource AudiouSourceReference => audioSourceReference;
        [SerializeField]
        private Animator _animator;
        
        [SerializeField] private ItemType _itemType;
        [SerializeField] protected float interactionDistance;
    
        protected delegate void InteractDelegate();
        protected InteractDelegate interactDelegate;

        protected int interactionLayer;
        [SerializeField] protected int outlineLayer = 11;
        [SerializeField] protected int fakeShaderOutlineLayer = 12;
        
        [Serializable]
        private class OtherGameobjectOutline
        {
            public GameObject outlineObject;
            public int interactionTrigger;
            public bool isFakeshader;
        }
    
        [SerializeField] 
        private OtherGameobjectOutline[] _otherGameobjectOutlineArray;
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
            else
            {
                _animator.StopPlayback();
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

        public float InteractionDistance()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void ExitInteract()
    {
        throw new System.NotImplementedException();
    }

    public void DisplayOutline()
    {
        if (gameObject.layer == outlineLayer)
            return;
        FadeOutline.Instance.FadeInOutline();
        gameObject.layer = outlineLayer;
        if (_otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in _otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = !outlineObject.isFakeshader ? outlineLayer : fakeShaderOutlineLayer;
        }
    }
}
