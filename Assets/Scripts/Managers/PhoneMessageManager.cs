using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneMessageManager : MonoBehaviour // Messagee manager
{
    public int currentDay = 0;
    private ChangePhoneUI phoneUI;
    [SerializeField] private MessagePerDay[] messageperdayArray;
    private UnityEngine.Events.UnityAction buttonCalback;
    public Action SentMessageFromDoctor;
    public Action SentMessageFromAgent;
    public Action SentMessageFromMister;
    [System.Serializable]
    public class MessagePerDay
    {
        public string Name;
        public PhoneChatInfo Doctor;
        public PhoneChatInfo Agent;
        public PhoneChatInfo Mister;
    }
    public enum MessageGuys
    {
        Doctor, Agent,Mister
    }
    private void Awake()
    {
        phoneUI = FindObjectOfType<ChangePhoneUI>();
    }
    private void Start()
    {
        AddListenersToSendButtonListeners();
    }
    public void RemoveSendButtonListeners() //make the callback buttons empty
    {
        for (int i = 0; i < phoneUI.MessageComponentsArray.Length; i++)
        {
            phoneUI.MessageComponentsArray[i].ButtonSend.onClick.RemoveAllListeners();
        }
    }
    public void AddListenersToSendButtonListeners() // add send listener to the specific day to send it
    {
        for (int i = 0; i < phoneUI.MessageComponentsArray.Length; i++)
        {
            int x = i;
            switch (x) //Define new callback
            {
                case 0:
                    buttonCalback = () => phoneUI.SendMessageOnThePhone(messageperdayArray[currentDay].Doctor);
                    SentMessageFromDoctor= () => phoneUI.SendMessageOnThePhone(messageperdayArray[currentDay].Doctor);
                    break;
                case 1:
                    buttonCalback = () => phoneUI.SendMessageOnThePhone(messageperdayArray[currentDay].Agent);
                    SentMessageFromAgent = () => phoneUI.SendMessageOnThePhone(messageperdayArray[currentDay].Agent);
                    break;
                case 2:
                    buttonCalback = () => phoneUI.SendMessageOnThePhone(messageperdayArray[currentDay].Mister);
                    SentMessageFromMister = () => phoneUI.SendMessageOnThePhone(messageperdayArray[currentDay].Mister);
                    break;
                default:
                    break;
            }
            //Add calback to button
            phoneUI.MessageComponentsArray[i].ButtonSend.onClick.AddListener(buttonCalback);
        }
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
        }
    }
}
