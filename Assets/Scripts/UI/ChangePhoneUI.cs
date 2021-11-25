using UnityEngine;
using UnityEngine.UI;

public class ChangePhoneUI : MonoBehaviour
{
    [SerializeField]private Transform playerbubbleChatPrefab;
    public Transform PlayerBubbleChatPrefab => playerbubbleChatPrefab;
    [SerializeField] private Transform someoneelseBubbleChatPrefab;
    public Transform ElseBubbleCharPrefab => someoneelseBubbleChatPrefab;
    [SerializeField]private CanvasGroup[] menus;
    [SerializeField] private PhoneChatInfos[] phoneChats;
    [System.Serializable]
    public class PhoneChatInfos
    {
        public PhoneChatInfo chatInfo;
        public VerticalLayoutGroup layoutGroupParent;
        public int messageIndex;

    }
    protected void Start()
    {
        ChatBubble.Create(this, phoneChats[0].layoutGroupParent.transform, Vector3.zero, "Hello World \r\n how are you? \r\n how was your day?  \r\n mine was awful", false);
    }
    private void Update()
    {
        if (InputManager.Instance.PhoneInput.clickedDebug)
        {
            RecieveMessageOnThePhone(0);
        }
    }
    private void RecieveMessageOnThePhone(int _chatsindex) //For debug propose only xd
    {
        switch (_chatsindex)
        {
            case 0:
                ChatBubble.Create(this, phoneChats[_chatsindex].layoutGroupParent.transform, Vector3.zero, phoneChats[_chatsindex].chatInfo.OtherMessages[phoneChats[_chatsindex].messageIndex], false);
                
                break;
            default:
                break;
        }
    }
    private void SendMessageOnThePhone(int _chatsindex)
    {
        switch (_chatsindex)
        {
            case 0:
                ChatBubble.Create(this, phoneChats[_chatsindex].layoutGroupParent.transform, Vector3.zero, phoneChats[_chatsindex].chatInfo.BrainMessages[phoneChats[_chatsindex].messageIndex], true);

                break;
            default:
                break;
        }
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
