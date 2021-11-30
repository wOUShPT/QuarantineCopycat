using UnityEngine;
using UnityEngine.UI;

public class ChangePhoneUI : MonoBehaviour
{
    [SerializeField]private Transform playerbubbleChatPrefab;
    public Transform PlayerBubbleChatPrefab => playerbubbleChatPrefab;
    [SerializeField] private Transform someoneelseBubbleChatPrefab;
    public Transform ElseBubbleCharPrefab => someoneelseBubbleChatPrefab;
    [SerializeField]private CanvasGroup[] menus;
    [SerializeField] private VerticalLayoutGroup[] verticalLayoutGroupsArray;
    public void RecieveMessageOnThePhone(PhoneChatInfo phoneChats) //Recieve message\\\\\\\\\\\\\\\
    {
        string value = phoneChats.OtherMessageArray.Dequeue();
        ChatBubble.Create(this, verticalLayoutGroupsArray[phoneChats.ChatIndex].transform, Vector3.zero, value, false);
        phoneChats.CanReply = true;
    }
    public void SendMessageOnThePhone(PhoneChatInfo phoneChats)
    {
        if (!phoneChats.CanReply)
            return; // don't send if the person didn't send you anything
        string text = phoneChats.BrainMessages.Dequeue();
        ChatBubble.Create(this, verticalLayoutGroupsArray[phoneChats.ChatIndex].transform, Vector3.zero, text, true);
        phoneChats.CanReply = false;
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
