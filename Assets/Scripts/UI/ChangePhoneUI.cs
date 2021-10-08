using UnityEngine;
using UnityEngine.UI;

public class ChangePhoneUI : MonoBehaviour
{
    [SerializeField]private GameObject[] menus;
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
                menus[i].SetActive(true);
            }
            else
            {
                menus[i].SetActive(false);
            }
        }
    }
}
