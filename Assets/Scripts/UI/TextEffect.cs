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
    private IEnumerator changeClipCourotine;
    private void Awake()
    {
        m_Camera = Camera.main;
        meshRenderer = GetComponent<MeshRenderer>();
        rectTransform = GetComponent<RectTransform>();
        textMesh = GetComponent<TextMeshPro>();
        mpb = new MaterialPropertyBlock();
        meshRenderer.GetPropertyBlock(mpb);
        changeClipCourotine = UpdateMaterialClip();
    }
    // Start is called before the first frame update
    void Start()
    {
        DisableRenderer();
        StartCoroutine(changeClipCourotine);
    }

    // Update is called once per frame
    void Update()
    {
        //Check visibility
        if (IsVisibleInAnyCorner() && IsCameraOnRange())
        {
            //Visible
            AdvancedDissolveProperties.Cutout.Standard.UpdateLocalProperty(textMesh.material, AdvancedDissolveProperties.Cutout.Standard.Property.Clip, 5);
            EnableCanvasGroup();
            VisibleTextBehaviour();
        }
        else
        {
            //Not Visible
            DisableRenderer();
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
    private void DisableRenderer()
    {
        if(!meshRenderer.enabled)
            return;
        meshRenderer.enabled = false;
    }
    private void EnableCanvasGroup()
    {
        if (meshRenderer.enabled)
            return;
        meshRenderer.enabled = true;
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
    IEnumerator UpdateMaterialClip()
    {
        while (true)
        {
            clipValue = Mathf.PingPong(Time.unscaledTime * .25f, 1);
            clipValue = Mathf.Clamp(clipValue, 0.2f, 0.8f);
            yield return null;
            mpb.SetFloat(propDissolveCutOffID, clipValue);
            meshRenderer.SetPropertyBlock(mpb);
        }
    }
}
