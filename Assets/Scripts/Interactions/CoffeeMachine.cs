using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class CoffeeMachine : InteractableBehaviour
{
    [SerializeField] private ItemType _item;
    [SerializeField] private float taskDuration;
    [SerializeField] private GameObject coffeeCup;
    [SerializeField] private ParticleSystem _coffeeParticleSystem;
    [SerializeField] private EventReference FMODEvent;
    private EventInstance _fmodInstance;
    [SerializeField] private UnityEvent _preEffect;
    [SerializeField] private UnityEvent _effect;
    private bool _wasInteracted;

    protected override void Awake()
    {
        base.Awake();
        if (!FMODEvent.IsNull)
        {
            _fmodInstance = RuntimeManager.CreateInstance(FMODEvent);
            _fmodInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        }
    }

    private void Start()
    {
        _wasInteracted = false;
    }

    public override void Interact()
    {
        if(InventoryManager.inventory.CheckHasItem(_item) && !_wasInteracted)
        {
            _wasInteracted = true;
            DisableInteraction();
            HideOutline();
            InventoryManager.inventory.RemoveItem(_item);
            StartCoroutine(DoCoffee());
        }
    }

    IEnumerator DoCoffee()
    {
        _preEffect.Invoke();
        coffeeCup.SetActive(true);
        if (_fmodInstance.isValid())
        {
            _fmodInstance.start();
        }
        yield return new WaitForSeconds(1f);
        _coffeeParticleSystem.Play();
        yield return new WaitForSeconds(taskDuration);
        _coffeeParticleSystem.Stop();
        yield return new WaitForSeconds(1f);
        _effect.Invoke();
    }
}
