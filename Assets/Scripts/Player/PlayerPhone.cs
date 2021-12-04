using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerPhone : MonoBehaviour
{
    private PhoneMessageManager messageManager;
    private ChangePhoneUI phoneUI;
    [SerializeField]private Button primaryButton;
    //make alpha 1 and 0
    [SerializeField] private CanvasGroup phoneCanvasGroup;

    private delegate void PhoneFunctionDelegate();
    private PhoneFunctionDelegate phoneDelegate;
    private bool hasPhone = false;
    private bool hasClicked = false;
    private void Awake()
    {
        phoneUI = FindObjectOfType<ChangePhoneUI>();
        phoneUI.ResetPhoneLayers();
        messageManager = FindObjectOfType<PhoneMessageManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        primaryButton.Select();
        phoneCanvasGroup.alpha = 0;
        phoneCanvasGroup.interactable = false;
        phoneCanvasGroup.blocksRaycasts = false;
        InputManager.Instance.TogglePhoneControls(false);
        phoneDelegate = DisplayPhone;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTurnedPhone();
    }
    private void CheckTurnedPhone()
    {
        if (!hasPhone)
        {
            return; // If player doesn't have a phone
        }
        if (InputManager.Instance.PlayerInput.UsePhone > 0)
        {
            phoneDelegate?.Invoke();
        }
        if( InputManager.Instance.PhoneInput.Return > 0 && !hasClicked)
        {
            if(phoneUI.Menus[0].Menu.alpha == 1f)
            {
                phoneDelegate?.Invoke(); // Turn Of
                return;
            }
            RetrocedeMenu();
        }
        if( InputManager.Instance.PhoneInput.Return == 0 && !InputManager.Instance.PhoneInput.Send)
        {
            if (hasClicked)
            {
                hasClicked = !hasClicked;
            }
        }
        if (InputManager.Instance.PhoneInput.Send)
        {
            if (phoneUI.CurrenMenu != null && phoneUI.CurrenMenu.IsChatMessage)
            {
                if (EventSystem.current.currentSelectedGameObject.TryGetComponent(out Scrollbar scrollbar) && EventSystem.current.currentSelectedGameObject.transform.parent.TryGetComponent(out ScrollRect scrollRect))
                {
                    //Send Message
                    switch (phoneUI.CurrenMenu.whoMessages)
                    {
                        case PhoneMessageManager.MessageGuys.Doctor:
                            messageManager.SentMessageFromDoctor?.Invoke();
                            break;
                        case PhoneMessageManager.MessageGuys.Agent:
                            messageManager.SentMessageFromAgent?.Invoke();
                            break;
                        case PhoneMessageManager.MessageGuys.Mister:
                            messageManager.SentMessageFromMister?.Invoke();
                            break;
                        default:
                            break;
                    }
                    //Change Scrollbar thing
                    phoneUI.ScrollbarToTop(scrollRect);
                }
            }
        }
    }
    private void RetrocedeMenu()
    {
        hasClicked = true;
        int currentMenuIndex = 0;
        for (int i = 0; i < phoneUI.Menus.Length; i++)
        {
            if(phoneUI.Menus[i].Menu.alpha == 1f)
            {
                currentMenuIndex = i;
                break;
            }
        }
        phoneUI.BackFromCurrentMenu(currentMenuIndex);
    }
    private void DisplayPhone() //Display immeadiatly for now, but in the future it will be an IK handle animation
    {
        primaryButton.Select();
        phoneCanvasGroup.alpha = 1;
        phoneCanvasGroup.interactable = true;
        InputManager.Instance.TogglePlayerControls(false);
        InputManager.Instance.TogglePhoneControls(true);
        phoneDelegate = HidePhone;
    }
    public void HidePhone() //Called by Animation as well
    {
        phoneCanvasGroup.alpha = 0;
        phoneCanvasGroup.interactable = false;
        InputManager.Instance.TogglePlayerControls(true);
        InputManager.Instance.TogglePhoneControls(false);
        phoneDelegate = DisplayPhone;
        phoneUI.ResetPhoneLayers();
    }
    public void ToogleHasPhoneToTrue()
    {
        hasPhone = true;
    }
}
