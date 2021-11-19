using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class PlayerPhone : MonoBehaviour
{
    private ChangePhoneUI phoneUI;
    [SerializeField]private Button primaryButton;
    //make alpha 1 and 0
    [SerializeField] private CanvasGroup phoneCanvasGroup;

    private delegate void PhoneFunctionDelegate();
    private PhoneFunctionDelegate phoneDelegate;
    private void Awake()
    {
        phoneUI = FindObjectOfType<ChangePhoneUI>();
        phoneUI.ResetPhoneLayers();
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
        if(InputManager.Instance.PlayerInput.UsePhone > 0 || InputManager.Instance.PhoneInput.Return > 0)
        {
            phoneDelegate?.Invoke();
        }
    }
    private void DisplayPhone()
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
}
