using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

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
    public MenuInfo CurrentMenu => currentMenuDisplayed;
    [SerializeField] private MessageComponents[] messageComponentArray= new MessageComponents[3];
    private MessageComponents currentMessageComponent;
    public MessageComponents[] MessageComponentsArray { get { return messageComponentArray; } set { messageComponentArray= value; } }
    [System.Serializable]
    public class MessageComponents
    {
        public string name;
        public VerticalLayoutGroup VerticalLayout;
        public Button ButtonSend;
        public TextMeshProUGUI Text;
    }
    private int messageChatIndex;
    [Header("Text Write Effect")]
    [SerializeField] private float timePerCharacter = .1f;
    [SerializeField] private bool invisibleCharacters = false;
    private int characterIndex = 0;
    private bool isTyping = false;
    public bool IsTyping => isTyping;
    private string textToWrite;
    private AudioSource audioSource;
    private IEnumerator typeEffectCourotine;
    private void Awake()
    {
        typeEffectCourotine = DisplayTextOnMessage();
    }
    public void RecieveMessageOnThePhone(PhoneChatInfo phoneChats) //Recieve message
    {
        string text = phoneChats.OtherMessageArray.Dequeue();
        
        ChatBubble.Create(this, messageComponentArray[phoneChats.ChatIndex].VerticalLayout.transform, Vector3.zero, text, false);
        phoneChats.CanReply = true;
    }
    public void SendMessageOnThePhone(PhoneChatInfo phoneChats)
    {
        if (!phoneChats.CanReply)
            return; // don't send if the person didn't send you anything
        textToWrite = phoneChats.BrainMessages.Dequeue();
        currentMessageComponent = messageComponentArray[phoneChats.ChatIndex];
        StartCoroutine(typeEffectCourotine);
        phoneChats.CanReply = false;
    }
    public void SetSelectButton(Button primaryButton) //For button be already selected by button clicker
    {
        if (isTyping)
            return;
        primaryButton.Select();
    }
    public void SetSelectButton(Scrollbar scrollbar) // For scrollbar be the first selected by button clicker
    {
        if (isTyping)
            return;
        scrollbar.Select();
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
    public void DisablePhoneMenu(CanvasGroup _canvasGroup) // by button clicker
    {
        if (isTyping)
            return;
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
    public void EnablePhoneMenu(CanvasGroup _canvasGroup) // by button clicker
    {
        if (isTyping)
            return;
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
                if( i >= 2)
                {
                    StartCoroutine(SetCurrentMenuDisplayed(i));
                    messageChatIndex = i;
                }
                else
                {
                    StopCoroutine(SetCurrentMenuDisplayed(messageChatIndex));
                    currentMenuDisplayed = menuInfos[i];
                }
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
    public void WriteAllText()
    {
        StopCoroutine(typeEffectCourotine);
        characterIndex = textToWrite.Length;
        CleanSendMessageTextAndSend();
    }
    private void StartTypingSound()
    {
        audioSource.Play();
    }
    private void StopTypingSound()
    {
        audioSource.Stop();
    }
    private IEnumerator DisplayTextOnMessage()
    {
        if(currentMessageComponent != null)
        {
            isTyping = true;
            characterIndex = 0;
            //StartTypingSound(); // Start typing sound
            while( characterIndex <  textToWrite.Length) //While the entire string is not displayed
            {
                yield return new WaitForSeconds(timePerCharacter);
                //Display next character
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) +"</color>"; // ask for the collegues
                }
                if(currentMessageComponent != null)
                    currentMessageComponent.Text.text = text;
            }
            yield return new WaitForSeconds(.25f);
            // clean text and create bubble
            CleanSendMessageTextAndSend();
        }
    }
    private void CleanSendMessageTextAndSend()
    {
        //clean text
        currentMessageComponent.Text.text = "";
        characterIndex = 0;
        isTyping = false;
        //StopTypingSound(); //Stop typing sound
        //Create bryan bubble
        ChatBubble.Create(this, currentMessageComponent.VerticalLayout.transform, Vector3.zero, textToWrite, true);
        //Force scrollbar to show bryan's message at bottom
        if (currentMessageComponent.VerticalLayout.transform.parent.parent.TryGetComponent(out ScrollRect scrollRect))
            ScrollbarToTop(scrollRect);
        currentMessageComponent = null;
    }
    private IEnumerator SetCurrentMenuDisplayed(int i) //In order not assume immediatly to type
    {
        yield return new WaitForSeconds(.25f);
        currentMenuDisplayed = menuInfos[i];
    }

}
