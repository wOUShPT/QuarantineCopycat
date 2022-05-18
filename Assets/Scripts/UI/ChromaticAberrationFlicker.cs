using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using Random = UnityEngine.Random;

public class ChromaticAberrationFlicker : MonoBehaviour
{
    public Volume volume;
    public float minChromaticIntensity;
    public float maxChromaticIntensity;
    private ChromaticAberration _chromaticAberration;


    private void Start()
    {
        if (volume.sharedProfile.TryGet(out ChromaticAberration temp))
        {
            _chromaticAberration = temp;
        }

        StartCoroutine(FlickerCoroutine());
    }

    IEnumerator FlickerCoroutine()
    {
        float elapsedTime = 0;
        float progress = 0;
        float targetTimeStamp = 0;
        float targetIntensity = 0;
        while (true)
        {
            if (progress == 0)
            {
                targetIntensity = Random.Range(minChromaticIntensity, maxChromaticIntensity);
                targetTimeStamp = Random.Range(0.1f, 0.2f);
            }

            if (progress < 1)
            {
                elapsedTime += Time.deltaTime;
                progress = elapsedTime / targetTimeStamp;
                SetIntensity(Mathf.Lerp(_chromaticAberration.intensity.value, targetIntensity, progress));
            }

            if (progress >= 1)
            {
                elapsedTime = 0;
                progress = 0;
            }
            yield return new WaitForEndOfFrame();
        }
    }
    
    private void SetIntensity(float intensity)
    {
        _chromaticAberration.intensity.value = intensity;
    }
}
