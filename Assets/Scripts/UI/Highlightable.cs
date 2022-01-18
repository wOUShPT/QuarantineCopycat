using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Highlightable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isHighlightable;
    [SerializeField]private float fadeSpeed = 4f;
    [SerializeField]private Vector3 highlightableScale = new Vector3(2,2,1);
    private Vector3 defaultScale = Vector3.one;
    private RectTransform rectTransform;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHighlightable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHighlightable = false;
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 updateTarget = isHighlightable ? highlightableScale : defaultScale;
        Vector3 currentScale = rectTransform.localScale;
        currentScale = Vector3.Lerp(currentScale, updateTarget, Time.unscaledTime * fadeSpeed);
        rectTransform.localScale = currentScale;
    }
}
