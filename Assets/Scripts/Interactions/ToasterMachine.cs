using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMOD.Studio;
using FMODUnity;

public class ToasterMachine : InteractableBehaviour
{
    [SerializeField] private ItemType _item;
    [SerializeField] private float taskDuration;
    [SerializeField] private GameObject toasts;
    [SerializeField] private Animator _toasterParticleSystemAnimator;
    [SerializeField] private Animator _toasterAnimator;
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
            StartCoroutine(DoToast());
        }
    }

    IEnumerator DoToast()
    {
        _preEffect.Invoke();
        toasts.SetActive(true);
        yield return new WaitForSeconds(1f);
        _toasterAnimator.Play("In");
        if (_fmodInstance.isValid())
        {
            _fmodInstance.start();
        }
        yield return new WaitForSeconds(taskDuration/3f);
        _toasterParticleSystemAnimator.speed = 1 / (2f * taskDuration / 3f);
        _toasterParticleSystemAnimator.Play("FadeSmokeIn");
        yield return new WaitForSeconds(2 * taskDuration / 3f);
        _toasterAnimator.Play("Out");
        yield return new WaitForSeconds(1f);
        _effect.Invoke();
        yield return new WaitForSeconds(5f);
        _toasterParticleSystemAnimator.speed = 2f;
        _toasterParticleSystemAnimator.Play("FadeSmokeOut");
    }
}
