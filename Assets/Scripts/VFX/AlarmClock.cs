using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    [SerializeField] private TextMeshPro[] textMeshes;
    [SerializeField] private float minAlpha;
    [SerializeField] private float maxAlpha;
    private float _defaultAlpha;
    private void Start()
    {
        _defaultAlpha = 0.6f;
        Flicker();
        //StartCoroutine(Switch());
    }

    //IEnumerator Switch()
    //{
    //    textMeshes[0].text = "00";
    //    textMeshes[2].text = "00";
    //    textMeshes[3].text = "AM";
    //    yield return new WaitForSeconds(6);
    //    textMeshes[0].text = "07";
    //    textMeshes[2].text = "00";
    //    textMeshes[3].text = "PM";
    //    yield return new WaitForSeconds(1f);
    //    textMeshes[0].text = "00";
    //    textMeshes[2].text = "00";
    //    textMeshes[3].text = "AM";
    //
    //}
    
    
    public void Flicker()
    {
        StartCoroutine(FlickerCoroutine());
    }

    public void SetIntensity(TextMeshPro tmp, float alpha)
    {
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.g, alpha);
    }

    IEnumerator FlickerCoroutine()
    {
        float elapsedTime = 0;
        float progress = 0;
        float targetTimeStamp = 0;
        float targetAlpha = 0;
        while (true)
        {
            if (progress == 0)
            {
                targetAlpha = Random.Range(minAlpha, maxAlpha);
                targetTimeStamp = Random.Range(0.1f, 0.5f);
            }

            if (progress < 1)
            {
                elapsedTime += Time.deltaTime;
                progress = elapsedTime / targetTimeStamp;
                foreach (var mesh in textMeshes)
                {
                    SetIntensity(mesh, Mathf.Lerp(mesh.color.a, targetAlpha, progress));
                }
                
            }

            if (progress >= 1)
            {
                elapsedTime = 0;
                progress = 0;
            }
            yield return null;
        }
    }
}
