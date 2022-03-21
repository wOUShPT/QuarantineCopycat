using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerPhone : MonoBehaviour
{
    private PhoneMessageManager messageManager;
    private ChangePhoneUI phoneUI;
    [SerializeField]private Button defaultSelectedButton;
    //make alpha 1 and 0
    [SerializeField] private CanvasGroup screenCanvasGroup;
    [SerializeField] private GameObject phoneModel;
    [SerializeField] private float AnimationInDuration;
    [SerializeField] private float AnimationOutDuration;
    [SerializeField] private float AnimationInAngle;
    [SerializeField] private float AnimationOutAngle;

    private delegate void PhoneFunctionDelegate();
    private PhoneFunctionDelegate phoneDelegate;
    private bool hasPhone = false;
    private bool hasClicked = false;
    private FPCameraHandler _fpCameraHandler;
    [SerializeField]
    private Animator _fpRigAnimator;
    
    private void Awake()
    {
        _fpCameraHandler = FindObjectOfType<FPCameraHandler>();
        phoneUI = FindObjectOfType<ChangePhoneUI>();
        phoneUI.ResetPhoneLayers();
        messageManager = FindObjectOfType<PhoneMessageManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultSelectedButton.Select();
        phoneModel.SetActive(false);
        screenCanvasGroup.alpha = 0;
        screenCanvasGroup.interactable = false;
        screenCanvasGroup.blocksRaycasts = false;
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
        if (InputManager.Instance.PlayerInput.UsePhone > 0 || InputManager.Instance.PhoneInput.HidePhone)
        {
            phoneDelegate?.Invoke();
        }
        if( InputManager.Instance.PhoneInput.Return && !hasClicked)
        {
            if (phoneUI.IsTyping)
                return;
            if(phoneUI.Menus[0].Menu.alpha == 1f)
            {
                //phoneDelegate?.Invoke(); // Turn Of
                return;
            }
            RetrocedeMenu();
        }
        
        if (InputManager.Instance.PhoneInput.Send && !hasClicked)
        {
            hasClicked = true;
            if (phoneUI.IsTyping)
            {
                phoneUI.WriteAllText();
                return;
            }
            SendMessage();
        }
        if (!InputManager.Instance.PhoneInput.Return && !InputManager.Instance.PhoneInput.Send)
        {
            if (hasClicked)
            {
                hasClicked = !hasClicked;
            }
        }
    }
    private void SendMessage()
    {
        if (phoneUI.CurrentMenu != null && phoneUI.CurrentMenu.IsChatMessage)
        {
            if (EventSystem.current.currentSelectedGameObject.TryGetComponent(out Scrollbar scrollbar) && EventSystem.current.currentSelectedGameObject.transform.parent.TryGetComponent(out ScrollRect scrollRect))
            {
                //Send Message
                switch (phoneUI.CurrentMenu.whoMessages)
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
    private void DisplayPhone() //Display immediately for now, but in the future it will be an IK handle animation
    {
        StartCoroutine(DisplayPhoneSequence());
    }
    
    private void HidePhone() //Display immediately for now, but in the future it will be an IK handle animation
    {
        StartCoroutine(HidePhoneSequence());
    }
    
    IEnumerator HidePhoneSequence() //Called by Animation as well
    {
        _fpRigAnimator.Play("PhoneOut");
        screenCanvasGroup.alpha = 0;
        screenCanvasGroup.interactable = false;
        InputManager.Instance.TogglePhoneControls(false);
        yield return new WaitForSeconds(AnimationOutDuration * 0.5f);
        _fpCameraHandler.RecenterCameraOnYaw(AnimationOutDuration, AnimationOutAngle);
        yield return new WaitForSeconds(AnimationOutDuration * 0.5f);
        yield return new WaitForSeconds(0.1f);
        phoneModel.SetActive(false);
        InputManager.Instance.TogglePlayerControls(true);
        PlayerProperties.Mode = PlayerProperties.State.Dynamic;
        PlayerProperties.FreezeAim = false;
        UIManager.Instance.ToggleReticle(true);
        phoneDelegate = DisplayPhone;
        phoneUI.ResetPhoneLayers();
    }
    public void ToggleHasPhoneToTrue()
    {
        hasPhone = true;
    }

    IEnumerator DisplayPhoneSequence()
    {
        InputManager.Instance.TogglePlayerControls(false);
        UIManager.Instance.ToggleReticle(false);
        PlayerProperties.FreezeAim = true;
        _fpCameraHandler.RecenterCameraOnYaw(AnimationInDuration, AnimationInAngle);
        yield return new WaitForSeconds(AnimationInDuration * 0.2f);
        phoneModel.SetActive(true);
        _fpRigAnimator.Play("PhoneIn");
        yield return new WaitForSeconds(AnimationInDuration * 0.8f);
        defaultSelectedButton.Select();
        screenCanvasGroup.alpha = 1;
        screenCanvasGroup.interactable = true;
        InputManager.Instance.TogglePhoneControls(true);
        phoneDelegate = HidePhone;
        yield return null;
    }
}
