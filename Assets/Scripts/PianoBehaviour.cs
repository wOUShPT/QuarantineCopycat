using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;

public class PianoBehaviour : MonoBehaviour
{
    [SerializeField] 
    private PlayerRaycast _playerRaycast;
    [SerializeField] 
    private AudioSource _audioSource;
    [SerializeField]
    private List<AudioClip> _notes;
    [SerializeField]
    private List<Collider> _keysColliders;

    private RaycastHit[] _hitResults;
    private float _timer;
    private float _coolDownTime;

    private void Start()
    {
        _hitResults = new RaycastHit[1];
        _timer = 0;
        _coolDownTime = 1f;
        _playerRaycast.raycastCallback += InteractKeyboard;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _timer = Mathf.Clamp(_timer, 0, _coolDownTime + 1);
    }

    /*void FixedUpdate()
    {
        int hits = Physics.RaycastNonAlloc(Camera.main.transform.position, Camera.main.transform.forward, _hitResults, 2);
        if (hits == 0)
        {
            return;
        }

        _timer += Time.deltaTime;
        _timer = Mathf.Clamp(_timer, 0, _coolDownTime + 1);
        Debug.Log(InputManager.Instance.PlayerInput.TapNote);
        if (InputManager.Instance.PlayerInput.TapNote == 1)
        {
            for (int i = 0; i < _keysColliders.Count; i++)
            {
                if (_hitResults[0].collider == _keysColliders[i] && (_timer >= _coolDownTime || _audioSource.clip != _notes[i]))
                {
                    _timer = 0;
                    _audioSource.clip = _notes[i];
                    _audioSource.Play();
                }
            }
        }
    }*/

    void InteractKeyboard(RaycastHit hit)
    {
        Debug.Log(hit.transform.gameObject);
        if (InputManager.Instance.PlayerInput.TapNote > 0)
        {
            for (int i = 0; i < _keysColliders.Count; i++)
            {
                if (hit.collider == _keysColliders[i] && (_timer >= _coolDownTime || _audioSource.clip != _notes[i]))
                {
                    _timer = 0;
                    _audioSource.clip = _notes[i];
                    _audioSource.Play();
                }
            }
        }
    }

}
