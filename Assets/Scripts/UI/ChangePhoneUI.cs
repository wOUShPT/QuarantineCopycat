using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangePhoneUI : MonoBehaviour
{
    [SerializeField]private Transform playerbubbleChatPrefab;
    public Transform PlayerBubbleChatPrefab => playerbubbleChatPrefab;
    [SerializeField] private Transform someoneelseBubbleChatPrefab;
    public Transform ElseBubbleCharPrefab => someoneelseBubbleChatPrefab;
    [SerializeField]private MenuInfo[] menuInfos;
    public MenuInfo[] Menus => menuInfos;
    [System.Serializable]
    public class MenuInfo
    {
        public string Name;
        public CanvasGroup Menu;
        public Button firstButtonSelected;
        public bool IsChatMessage; // Know if it's for chatting with someone else or not
        public PhoneMessageManager.MessageGuys whoMessages;
    }
    private MenuInfo currentMenuDisplayed;
    public MenuInfo CurrenMenu => currentMenuDisplayed;
    [SerializeField] private VerticalLayoutGroup[] verticalLayoutGroupsArray;
    [SerializeField] private Button[] buttonSendArray = new Button[3];
    public Button[] ButtonsSendArray { get { return buttonSendArray; } set { buttonSendArray = value; } }

    public void RecieveMessageOnThePhone(PhoneChatInfo phoneChats) //Recieve message
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
        for (int i = 0; i < menuInfos.Length; i++) // make all menus invisible but the main menu 
        {
            if( i == 0)
            {
                menuInfos[i].Menu.alpha = 1f;
                menuInfos[i].Menu.interactable = true;
                menuInfos[i].Menu.blocksRaycasts = true;
                currentMenuDisplayed = menuInfos[i];
            }
            else
            {
                menuInfos[i].Menu.alpha = 0f;
                menuInfos[i].Menu.interactable = false;
                menuInfos[i].Menu.blocksRaycasts = false;
            }
        }
    }
    public void BackFromCurrentMenu(int index)
    {
        if(index >= 2 && index <= 4)
        {
            DisablePhoneMenu(menuInfos[index].Menu);
            EnablePhoneMenu(menuInfos[1].Menu); // Show all messages
            SetSelectButton(menuInfos[1].firstButtonSelected);
            currentMenuDisplayed = menuInfos[1];
        }
        else if(index == 1)
        {
            DisablePhoneMenu(menuInfos[index].Menu);
            EnablePhoneMenu(menuInfos[0].Menu); //Show the main one
            SetSelectButton(menuInfos[0].firstButtonSelected);
            currentMenuDisplayed = menuInfos[0];
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
        SaveMenuInfoDisplayed(_canvasGroup);
    }
    private void SaveMenuInfoDisplayed(CanvasGroup canvasGroup)
    {
        for (int i = 0; i < menuInfos.Length; i++)
        {
            if(canvasGroup == menuInfos[i].Menu)
            {
                currentMenuDisplayed = menuInfos[i];
                break;
            }
        }
    }
    public void ScrollbarToTop(ScrollRect scrollrect)
    {
        Canvas.ForceUpdateCanvases();
        StartCoroutine(WaitNextFrameToUpdateScrollRect(scrollrect));
    }
    IEnumerator WaitNextFrameToUpdateScrollRect(ScrollRect scrollRect)
    {
        yield return 0; // wait for the next frame
        //Change the current vertical scroll position.
        scrollRect.verticalNormalizedPosition = 0.0f;
        Canvas.ForceUpdateCanvases();
    }
}
