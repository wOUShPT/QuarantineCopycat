using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class CoffeeMachine : MonoBehaviour
{
    [SerializeField] private float taskDuration;
    [SerializeField] private GameObject coffeeCup;
    [SerializeField] private ParticleSystem _coffeeParticleSystem;
    [SerializeField] private EventReference FMODEvent;
    private EventInstance _fmodInstance;
    [SerializeField] private UnityEvent _preEffect;
    [SerializeField] private UnityEvent _effect;

    private void Awake()
    {
        if (!FMODEvent.IsNull)
        {
            _fmodInstance = RuntimeManager.CreateInstance(FMODEvent);
            _fmodInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        }
    }

    public void StartCoffee()
    {
        StartCoroutine(DoCoffee());
    }

    IEnumerator DoCoffee()
    {
        _preEffect.Invoke();
        coffeeCup.SetActive(true);
        if (_fmodInstance.isValid())
        {
            _fmodInstance.start();
        }
        yield return new WaitForSeconds(2.5f);
        _coffeeParticleSystem.Play();
        yield return new WaitForSeconds(taskDuration);
        _coffeeParticleSystem.Stop();
        yield return new WaitForSeconds(1f);
        _effect.Invoke();
    }

    public void OnDestroy()
    {
        _fmodInstance.release();
    }
}
