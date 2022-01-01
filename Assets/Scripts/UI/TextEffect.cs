using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextEffect : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private Mesh mesh;
    private Vector3[] vertices;
    [SerializeField]private  float NOISE_MAGNITUDE_ADJUSTMENT = 0.06f;
    [SerializeField]private float NOISE_FREQUENCY_ADJUSTMENT = 15f;
    private Camera m_Camera;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    [SerializeField]private LayerMask layerMask;
    private void Awake()
    {
        m_Camera = Camera.main;
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        DisableCanvasGroup();
    }

    // Update is called once per frame
    void Update()
    {
        //Check visibility
        if (IsVisibleInAnyCorner() && CanSeeOnFrustom())
        {
            //Visible
            EnableCanvasGroup();
            VisibleTextBehaviour();
        }
        else
        {
            //Not Visible
            DisableCanvasGroup();
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
        textMesh.canvasRenderer.SetMesh(mesh);
    }
    private Vector2 Wobble(float time) // per vertex wobble effect
    {
        float scaledAdjust = textMesh.fontSize * NOISE_MAGNITUDE_ADJUSTMENT;
        return new Vector2((Mathf.PerlinNoise(time * NOISE_FREQUENCY_ADJUSTMENT, 0) - 0.5f) * scaledAdjust, (Mathf.PerlinNoise(time * NOISE_FREQUENCY_ADJUSTMENT, 100) - 0.5f) * scaledAdjust);
    }
    private void DisableCanvasGroup()
    {
        if(canvasGroup.alpha == 0f)
            return;
        canvasGroup.alpha = 0f;
    }
    private void EnableCanvasGroup()
    {
        if (canvasGroup.alpha == 1f)
            return;
        canvasGroup.alpha = 1f;
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
    private bool CanSeeOnFrustom()
    {
        Vector3 textPos = m_Camera.WorldToViewportPoint(transform.position);
        if(textPos.z > 0)
        {
            RaycastHit hit;
            if(Physics.Linecast(m_Camera.transform.position, transform.position, out hit, layerMask))
            {
                Debug.Log(hit.collider.gameObject.name);
                return false;
            }
            else
            {
                return true;
            }
            //return !Physics.Linecast(m_Camera.transform.position, transform.position, out hit);
        }
        return false;
    }


}
