using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AmazingAssets.AdvancedDissolve;
public class TextEffect : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Mesh mesh;
    private Vector3[] vertices;
    [SerializeField]private  float NOISE_MAGNITUDE_ADJUSTMENT = 0.06f;
    [SerializeField]private float NOISE_FREQUENCY_ADJUSTMENT = 1.2f;
    private Camera m_Camera;
    private MeshRenderer meshRenderer;
    private RectTransform rectTransform;
    [SerializeField] private float minDistance = 5.7f;
    private readonly int propDissolveCutOffID = Shader.PropertyToID("_AdvancedDissolveCutoutStandardClip");
    private MaterialPropertyBlock mpb;
    [SerializeField] private float clipValue = 0.5f;
    private float endValue = 0f;
    [SerializeField] private float minEndValue = 0.2f;
    [SerializeField] private float maxEndValue = 1f;
    [SerializeField] private float mediumEndValue = 0.8f;
    private delegate void DissolveBehaviour();
    private DissolveBehaviour dissolveBehaviour;
    private bool isDoingCourotine = false;
    private void Awake()
    {
        m_Camera = Camera.main;
        meshRenderer = GetComponent<MeshRenderer>();
        rectTransform = GetComponent<RectTransform>();
        textMesh = GetComponent<TextMeshPro>();
        mpb = new MaterialPropertyBlock();
        meshRenderer.GetPropertyBlock(mpb);
    }
    private void Start()
    {
        DissolveText(minEndValue);
    }
    private void Update()
    {
        VisibleTextBehaviour();
    }
    private void TextBehaviour()
    {
        //Check visibility
        if (IsCameraOnRange())
        {
            //Dissappear text
            DissolveText(maxEndValue);
        }
        else
        {
            //Not Visible
            DissolveText(mediumEndValue);
            
        }
    }
    private void VisibleTextBehaviour()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
        for (int i = 0; i < textMesh.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textMesh.textInfo.characterInfo[i];
            //Each character has 4 vertices
            int index = charInfo.vertexIndex;
            Vector3 offset = Wobble(Time.time + i);
            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }
        mesh.vertices = vertices;
    }
    private Vector2 Wobble(float time) // per vertex wobble effect
    {
        float scaledAdjust = textMesh.fontSize * NOISE_MAGNITUDE_ADJUSTMENT;
        return new Vector2((Mathf.PerlinNoise(time * NOISE_FREQUENCY_ADJUSTMENT, 0) - 0.5f) * scaledAdjust, (Mathf.PerlinNoise(time * NOISE_FREQUENCY_ADJUSTMENT, 100) - 0.5f) * scaledAdjust);
    }
    private void DissolveText(float _endValue)
    {
        if (endValue ==_endValue)
            return;
        StopAllCoroutines();
        endValue = _endValue;
        StartCoroutine(UpdateMaterialClip(endValue));
        isDoingCourotine = true;
    }
    private bool IsVisibleInAnyCorner() //Determines if this recttransform is at least partially visible
    {
        return CountCornersVisibleFrom() > 0; // True if any corner are visible
    }
    private int CountCornersVisibleFrom()
    {
        Rect screenBounds = new Rect(0f, 0f, Screen.width, Screen.height);
        Vector3[] objectCorners = new Vector3[4];
        rectTransform.GetWorldCorners(objectCorners);
        int visibleCorners = 0;
        for (int i = 0; i < objectCorners.Length; i++)
        {
            Vector3 screenPos = m_Camera.WorldToScreenPoint(objectCorners[i]);
            if (screenBounds.Contains(screenPos))
            {
                visibleCorners++;
            }
        }
        return visibleCorners;
    }

    private bool IsCameraOnRange()
    {
        if(Vector3.Distance(m_Camera.transform.position, transform.position) < minDistance)
        {
            return true;
        }
        return false;
    }
    IEnumerator UpdateMaterialClip(float _endValue)
    {
        float time = 0;
        while (time < 1.0f)
        {
            clipValue = Mathf.Lerp(mpb.GetFloat(propDissolveCutOffID), endValue, time);
            time += 0.5f * Time.deltaTime;
            yield return null;
            mpb.SetFloat(propDissolveCutOffID, clipValue);
            meshRenderer.SetPropertyBlock(mpb);
        }
        isDoingCourotine = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextBehaviour();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DissolveText(minEndValue);
        }
        
    }
}
