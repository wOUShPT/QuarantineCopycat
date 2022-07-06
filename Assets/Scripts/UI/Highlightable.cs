using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Highlightable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool _isHighlightable;
    [SerializeField]private float fadeSpeed = 4f;
    [SerializeField]private Vector3 highlightableScale = new Vector3(2,2,1);
    private Vector3 _defaultScale = Vector3.one;
    private RectTransform _rectTransform;
    [SerializeField] private EventReference UIHover;
    [SerializeField] private EventReference UISelection;
    private EventInstance _UIHoverInstance;
    private EventInstance _UISelectionInstance;
    private Button button;

    private void OnEnable()
    {
        _UIHoverInstance = RuntimeManager.CreateInstance(UIHover);
        _UISelectionInstance = RuntimeManager.CreateInstance(UISelection);
        button = GetComponent<Button>();
        button.onClick.AddListener(PlaySelectionSound);

    }

    private void OnDisable()
    {
        _UIHoverInstance.release();
        _UISelectionInstance.release();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Entered " + gameObject.name);
        _isHighlightable = true;
        _UIHoverInstance.start();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exited " + gameObject.name);
        _isHighlightable = false;
    }
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void PlayHoverSound()
    {
        _UIHoverInstance.start();
    }
        

    public void PlaySelectionSound()
    {
        _UISelectionInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 updateTarget = _isHighlightable ? highlightableScale : _defaultScale;
        Vector3 currentScale = _rectTransform.localScale;
        currentScale = Vector3.Lerp(currentScale, updateTarget, Time.unscaledTime * fadeSpeed);
        _rectTransform.localScale = currentScale;
    }
}
