using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class LoadingScreen : MonoBehaviour
{
    public float currentProgress;
    public Slider progressSlider;
    private Animator _animator;
    public MainMenuBehaviour MainMenuBehaviour;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        SetProgressSlider();
    }

    public void TransitionAnimation()
    {
        _animator.SetTrigger("FadeOut");
    }
    
    public void SetProgressSlider()
    {
        progressSlider.value = currentProgress;
    }
}
