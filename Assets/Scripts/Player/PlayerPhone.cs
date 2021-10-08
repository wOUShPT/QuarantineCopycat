using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class PlayerPhone : MonoBehaviour
{
    private ChangePhoneUI changePhone;
    [SerializeField]private Button primaryButton;
    [SerializeField] private GameObject phone;

    private delegate void PhoneFunctionDelegate();
    private PhoneFunctionDelegate phoneDelegate;
    private void Awake()
    {
        changePhone = FindObjectOfType<ChangePhoneUI>();
        changePhone.ResetPhoneLayers();
    }
    // Start is called before the first frame update
    void Start()
    {
        primaryButton.Select();
        phone.gameObject.SetActive(false);
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
        phone.SetActive(true);
        InputManager.Instance.TogglePlayerControls(false);
        InputManager.Instance.TogglePhoneControls(true);
        phoneDelegate = HidePhone;
    }
    public void HidePhone() //Called by Animation as well
    {
        phone.SetActive(false);
        InputManager.Instance.TogglePlayerControls(true);
        InputManager.Instance.TogglePhoneControls(false);
        phoneDelegate = DisplayPhone;
        changePhone.ResetPhoneLayers();
    }
}
