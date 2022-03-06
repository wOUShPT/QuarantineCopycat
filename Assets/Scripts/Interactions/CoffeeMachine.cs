using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoffeeMachine : InteractableBehaviour
{
    [SerializeField] private ItemType _item;
    [SerializeField] private float taskDuration;
    [SerializeField] private GameObject coffeeCup;
    [SerializeField] private ParticleSystem _coffeeParticleSystem;

    [SerializeField] private UnityEvent _preEffect;
    [SerializeField] private UnityEvent _effect;
    private bool _wasInteracted;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _wasInteracted = false;
    }

    public override void Interact()
    {
        if(InventoryManager.inventory.CheckHasItem(_item) && !_wasInteracted)
        {
            StartCoroutine(DoCoffee());
        }
    }

    IEnumerator DoCoffee()
    {
        yield return new WaitForSeconds(taskDuration);
    }

    //Called by the timeline
    public void CoffeeIsReady()
    {

    }

    public void PlaceCoffeeAfterDrink()
    {
        
    }
}
