using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMOD.Studio;
using FMODUnity;

public class ToasterMachine: MonoBehaviour
{
    [SerializeField] private float taskDuration;
    [SerializeField] private GameObject toasts;
    [SerializeField] private Animator _toasterParticleSystemAnimator;
    [SerializeField] private Animator _toasterAnimator;
    [SerializeField] private EventReference FMODToasterInEvent;
    [SerializeField] private EventReference FMODToasterOutEvent;
    private EventInstance _eventInstance;
    [SerializeField] private UnityEvent _preEffect;
    [SerializeField] private UnityEvent _effect;

    public void StartToaster()
    {
        StartCoroutine(DoToast());
    }

    IEnumerator DoToast()
    {
        _preEffect.Invoke();
        toasts.SetActive(true);
        yield return new WaitForSeconds(1f);
        _toasterAnimator.Play("In");
        if (!FMODToasterInEvent.IsNull)
        {
            _eventInstance = RuntimeManager.CreateInstance(FMODToasterInEvent);
            _eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            _eventInstance.start();
        }
        yield return new WaitForSeconds(taskDuration/3f);
        _toasterParticleSystemAnimator.speed = 1 / (2f * taskDuration / 3f);
        _toasterParticleSystemAnimator.Play("FadeSmokeIn");
        yield return new WaitForSeconds(2 * taskDuration / 3f);
        if (!FMODToasterOutEvent.IsNull)
        {
            _eventInstance = RuntimeManager.CreateInstance(FMODToasterOutEvent);
            _eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            _eventInstance.start();
        }
        _toasterAnimator.Play("Out");
        yield return new WaitForSeconds(1f);
        _effect.Invoke();
        yield return new WaitForSeconds(5f);
        _toasterParticleSystemAnimator.speed = 2f;
        _toasterParticleSystemAnimator.Play("FadeSmokeOut");
    }

    private void OnDestroy()
    {
        _eventInstance.release();
    }
}
