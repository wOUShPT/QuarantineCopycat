using UnityEngine;
using UnityEngine.UI;

public class ChangePhoneUI : MonoBehaviour
{
    public Transform bubbleChatPrefab;
    [SerializeField]private CanvasGroup[] menus;
    protected void Start()
    {
        ChatBubble.Create(this, menus[2].transform.GetChild(1).transform, Vector3.zero, "Hello World \r\n how are you? \r\n how was your day?  \r\n mine was awful");
    }
    public void SetSelectButton(Button primaryButton)
    {
        primaryButton.Select();
    }
    public void ResetPhoneLayers()
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if( i == 0)
            {
                menus[i].alpha = 1f;
                menus[i].interactable = true;
                menus[i].blocksRaycasts = true;
            }
            else
            {
                menus[i].alpha = 0f;
                menus[i].interactable = false;
                menus[i].blocksRaycasts = false;
            }
        }
    }
    public void DisablePhoneMenu(CanvasGroup _canvasGroup)
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
    public void EnablePhoneMenu(CanvasGroup _canvasGroup)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }
}
