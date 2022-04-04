using System;
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
    [SerializeField] private Camera phoneCanvasCamera;
    [SerializeField] private CanvasGroup phoneCanvasGroup;
    [SerializeField] private GameObject phoneModel;
    [SerializeField] private float animationInDuration;
    [SerializeField] private float animationInAngle;
    [SerializeField] private float animationOutDuration;
    [SerializeField] private float animationOutAngle;

    private delegate void PhoneFunctionDelegate();
    private PhoneFunctionDelegate phoneDelegate;
    private bool hasPhone = false;
    private bool hasClicked = false;
    [SerializeField] private FPCameraHandler _fpCameraHandler;
    [SerializeField]
    private Animator _fpRigAnimator;

    private void Awake()
    {
        phoneUI = FindObjectOfType<ChangePhoneUI>();
        phoneUI.ResetPhoneLayers();
        messageManager = FindObjectOfType<PhoneMessageManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultSelectedButton.Select();
        phoneModel.SetActive(false);
        phoneCanvasCamera.gameObject.SetActive(false);
        phoneCanvasGroup.alpha = 0;
        phoneCanvasGroup.interactable = false;
        phoneCanvasGroup.blocksRaycasts = false;
        InputManager.Instance.TogglePhoneControls(false);
        phoneDelegate = DisplayPhone;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPhone)
        {
            return; // If player doesn't have a phone
        }
        
        CheckInput();
    }
    private void CheckInput()
    {
        if (InputManager.Instance.PlayerInput.UsePhone > 0 || InputManager.Instance.PhoneInput.HidePhone)
        {
            phoneDelegate?.Invoke();
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
    
    public void DisplayPhone() //Display immediately for now, but in the future it will be an IK handle animation
    {
        StartCoroutine(DisplayPhoneSequence());
    }
    
    public void HidePhone() //Display immediately for now, but in the future it will be an IK handle animation
    {
        StartCoroutine(HidePhoneSequence());
    }

    IEnumerator HidePhoneSequence() //Called by Animation as well
    {
        _fpRigAnimator.speed = 2.2f * animationOutDuration;
        _fpRigAnimator.Play("PhoneOut");
        phoneCanvasGroup.alpha = 0;
        phoneCanvasGroup.interactable = false;
        StopCoroutine(CheckUIInput());
        InputManager.Instance.TogglePhoneControls(false);
        yield return new WaitForSeconds(0.5f * animationOutDuration);
        _fpCameraHandler.MoveCameraOnYaw(animationOutDuration, animationOutAngle);
        yield return new WaitForSeconds(0.5f * animationOutDuration);
        yield return new WaitForSeconds(0.1f);
        phoneModel.SetActive(false);
        InputManager.Instance.TogglePlayerControls(true);
        PlayerProperties.Mode = PlayerProperties.State.Dynamic;
        PlayerProperties.FreezeAim = false;
        UIManager.Instance.ToggleReticle(true);
        phoneDelegate = DisplayPhone;
        phoneUI.ResetPhoneLayers();
        phoneCanvasCamera.gameObject.SetActive(false);
    }
    public void ToggleHasPhoneToTrue()
    {
        hasPhone = true;
    }

    IEnumerator DisplayPhoneSequence()
    {
        phoneCanvasCamera.gameObject.SetActive(true);
        InputManager.Instance.TogglePlayerControls(false);
        UIManager.Instance.ToggleReticle(false);
        PlayerProperties.FreezeAim = true;
        _fpCameraHandler.MoveCameraOnYaw(animationInDuration, animationInAngle);
        yield return new WaitForSeconds(0.2f * animationInDuration);
        phoneModel.SetActive(true);
        _fpRigAnimator.speed = 1.5f * animationInDuration;
        _fpRigAnimator.Play("PhoneIn");
        yield return new WaitForSeconds(0.8f * animationInDuration);
        yield return new WaitForSeconds(0.1f);
        defaultSelectedButton.Select();
        phoneCanvasGroup.alpha = 1;
        phoneCanvasGroup.interactable = true;
        InputManager.Instance.TogglePhoneControls(true);
        phoneDelegate = HidePhone;
        _fpRigAnimator.speed = 1;
        StartCoroutine(CheckUIInput());
    }


    IEnumerator CheckUIInput()
    {
        while (true)
        {
            if( InputManager.Instance.PhoneInput.Return && !hasClicked)
            {
                if (phoneUI.IsTyping)
                    yield return null;
            
                if(phoneUI.Menus[0].Menu.alpha == 1f)
                {
                    //phoneDelegate?.Invoke(); // Turn Off
                    yield return null;
                }
            
                RetrocedeMenu();
            }
        
            if (InputManager.Instance.PhoneInput.Send && !hasClicked)
            {
                hasClicked = true;
                if (phoneUI.IsTyping)
                {
                    phoneUI.WriteAllText();
                    yield return null;
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
            yield return new WaitForEndOfFrame();
        }
    }
}
