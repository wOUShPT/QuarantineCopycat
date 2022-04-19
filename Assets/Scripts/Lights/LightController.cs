using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental;

public class LightController : MonoBehaviour
{
    [SerializeField] MeshRenderer _lightMeshRenderer;

    [SerializeField] private Material _onMaterial;
    [SerializeField] private Material _offMaterial;
    [SerializeField] private Light _lightComponent;
    [SerializeField] private float minLightIntensity;
    [SerializeField] private float maxLightIntensity;
    private float _defaultLightIntensity;

    private void Start()
    {
        _defaultLightIntensity = _lightComponent.intensity;
        Flicker();
    }

    public void TurnOn()
    {
        SetIntensity(_defaultLightIntensity);
        _lightMeshRenderer.material = _onMaterial;
        _lightComponent.enabled = true;
    }

    public void TurnOff()
    {
        _lightMeshRenderer.material = _offMaterial;
        _lightComponent.enabled = false;
    }

    public void Flicker()
    {
        StartCoroutine(FlickerCoroutine());
    }

    public void SetIntensity(float intensity)
    {
        _lightComponent.intensity = intensity;
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
                targetIntensity = Random.Range(minLightIntensity, maxLightIntensity);
                targetTimeStamp = Random.Range(0.1f, 0.2f);
            }

            if (progress < 1)
            {
                elapsedTime += Time.deltaTime;
                progress = elapsedTime / targetTimeStamp;
                SetIntensity(Mathf.Lerp(_lightComponent.intensity, targetIntensity, progress));
            }

            if (progress >= 1)
            {
                elapsedTime = 0;
                progress = 0;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
