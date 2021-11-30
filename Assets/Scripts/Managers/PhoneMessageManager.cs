using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMessageManager : MonoBehaviour
{
    public int currentDay = 0;
    private ChangePhoneUI phoneUI;
    [SerializeField] private MessagePerDay[] messageperdayArray;
    [System.Serializable]
    public class MessagePerDay
    {
        public string Name;
        public PhoneChatInfo Doctor;
        public PhoneChatInfo Agent;
        public PhoneChatInfo Mister;

    }

    private void Awake()
    {
        phoneUI = FindObjectOfType<ChangePhoneUI>();
    }
    private void Start()
    {
        SetMessageAndDay(0);
        SetMessageAndDay(0);
        SetMessageAndDay(0);
    }
    public void SetMessageAndDay( int personIndex)
    {
        switch (personIndex)
        {
            case 0: //For Doctor
                if (messageperdayArray[currentDay].Doctor.OtherMessageArray.Count == 0)
                {
                    return; //Queue is empty
                }
                phoneUI.RecieveMessageOnThePhone(messageperdayArray[currentDay].Doctor);
                break;
            case 1: // For Agent
                if (messageperdayArray[currentDay].Agent.OtherMessageArray.Count == 0)
                {
                    return; //Queue is empty
                }
                phoneUI.RecieveMessageOnThePhone(messageperdayArray[currentDay].Agent);
                break;
            case 2: //For Mister
                if (messageperdayArray[currentDay].Mister.OtherMessageArray.Count == 0)
                {
                    return; //Queue is empty
                }
                phoneUI.RecieveMessageOnThePhone(messageperdayArray[currentDay].Mister);
                break;
            default:
                break;
        }
    }

    
}
