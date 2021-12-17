using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutline : Singleton<FadeOutline>
{
    [SerializeField] private Material outlineMaterial;
    private static Material OutlineMaterial;
    private float minvalue = 0f;
    [SerializeField]private float maxValue = 5f;
    //private float timeElapsed = 0f;
    [SerializeField]private static float lerpDuration = .5f;
    //private float valueToLerp;
    private IEnumerator FadeInCourotine;
    private static IEnumerator FadeOutCourotine;
    private delegate void FadeAction(float startvalue, float endvalue);
    private FadeAction fadeAction;
    // Start is called before the first frame update
    void Start()
    {
        OutlineMaterial = outlineMaterial;
        outlineMaterial.SetFloat("_OutlineWidth", 3f);
        FadeOutCourotine = FadeOutlineInObject(maxValue, minvalue); // to fade out
    }
    private void Update()
    {
        Debug.Log(FadeInCourotine);
    }

    public void FadeInOUtline()
    {
        Debug.Log("Fade In");

        if(FadeInCourotine != null)
        {
            StopCoroutine(FadeInCourotine);
        }
        FadeInCourotine = FadeOutlineInObject(minvalue, maxValue); // "Reset Courotine
        StartCoroutine(FadeInCourotine);
    }
    public static void FadeeOutOutline()
    {
    }
    private IEnumerator FadeOutlineInObject(float startValue, float endValue)
    {
        
        Debug.Log("Courotine");
        float timeElapsed = 0f;
        float valueToLerp = startValue;
        OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);
        yield return null;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        valueToLerp = endValue;
        OutlineMaterial.SetFloat("_OutlineWidth", valueToLerp);

    }
}
