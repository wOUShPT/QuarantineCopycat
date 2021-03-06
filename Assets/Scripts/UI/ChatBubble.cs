using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    public static void Create(ChangePhoneUI phoneUI, Transform parent, Vector3 localPosition, string text, bool isFromPlayer)
    {
        Transform chatBubbleTransform = Instantiate(isFromPlayer ? phoneUI.PlayerBubbleChatPrefab : phoneUI.ElseBubbleCharPrefab, parent);
        chatBubbleTransform.localPosition = localPosition;
        chatBubbleTransform.GetComponent<ChatBubble>().Setup(text);
    }
    [SerializeField] private RectTransform pivotRectTransform;
    [SerializeField]private RectTransform backgroundrectTransform;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private void Setup(string text)
    {
        //Setup bubble
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(true);

        Vector2 padding = new Vector2(0f, 20f);
        backgroundrectTransform.sizeDelta = new Vector2(backgroundrectTransform.sizeDelta.x, textSize.y + padding.y);
        pivotRectTransform.sizeDelta = backgroundrectTransform.sizeDelta;
    }
}
