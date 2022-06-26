using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutline : Singleton<FadeOutline>
{
    private float minvalue = 0f;
    [SerializeField]private float maxValue = 5f;
    [SerializeField]private float lerpDuration = .5f;
    private IEnumerator FadeInCourotine;
    private static IEnumerator FadeOutCourotine;
    private delegate void FadeAction(float startvalue, float endvalue);
    private FadeAction fadeAction;
    private int outlinePropertyID;
    // Start is called before the first frame update
    void Start()
    {
        //OutlineMaterial = outlineMaterial;
        outlinePropertyID = Shader.PropertyToID("_OutlineWidth");
        Shader.SetGlobalFloat(outlinePropertyID, 3f);
        //.SetFloat("_OutlineWidth", 3f);
        FadeOutCourotine = FadeOutlineInObject(maxValue, minvalue); // to fade out
    }
    public void FadeInOutline()
    {
        if(FadeInCourotine != null)
        {
            StopCoroutine(FadeInCourotine);
        }
        FadeInCourotine = FadeOutlineInObject(minvalue, maxValue); // "Reset Courotine
        StartCoroutine(FadeInCourotine);
    }

    public void AttentionHighlight()
    {
        
    }
    
    public static void FadeOutOutline()
    {
    }
    private IEnumerator FadeOutlineInObject(float startValue, float endValue)
    {
        
        float timeElapsed = 0f;
        float valueToLerp = startValue;
        Shader.SetGlobalFloat(outlinePropertyID, valueToLerp);
        //OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);
        yield return null;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            Shader.SetGlobalFloat(outlinePropertyID, valueToLerp);
            //OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        valueToLerp = endValue;
        Shader.SetGlobalFloat(outlinePropertyID, valueToLerp);
        //OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);

    }

    private IEnumerator AttentionHighlightAnimation(float startValue, float endValue)
    {
        float timeElapsed = 0f;
        float valueToLerp = startValue;
        Shader.SetGlobalFloat(outlinePropertyID, valueToLerp);
        //OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);
        yield return null;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            Shader.SetGlobalFloat(outlinePropertyID, valueToLerp);
            //OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        valueToLerp = endValue;
        Shader.SetGlobalFloat(outlinePropertyID, valueToLerp);
        //OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);

    }
}
