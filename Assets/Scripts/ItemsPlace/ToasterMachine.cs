using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToasterMachine : InteractableBehaviour
{
    [SerializeField] private ItemType _item;
    [SerializeField] private float taskDuration;
    [SerializeField] private GameObject toasts;
    [SerializeField] private ParticleSystem _toasterParticleSystem;

    [SerializeField] private UnityEvent _preEffect;
    [SerializeField] private UnityEvent _effect;
    protected override void Awake()
    {
        base.Awake();
    }
    
    
    IEnumerator DoToast()
    {
        yield return new WaitForSeconds(taskDuration);
    }
}
