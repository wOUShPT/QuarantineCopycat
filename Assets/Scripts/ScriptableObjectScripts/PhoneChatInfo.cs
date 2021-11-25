using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Chat Info")]
public class PhoneChatInfo : ScriptableObject
{
    [SerializeField]private new string name;// name the person we're talking
    public string Name => name;
    [SerializeField]private int currentMessageIndex;
    public int CurrentIndex => currentMessageIndex;
    [TextArea(2,8)]
    [SerializeField] private string[] otherMessageArray;
    public string[] OtherMessages => otherMessageArray;

    [TextArea(2, 8)]
    [SerializeField] private string[] brainMessageArray; // protagonist's protagonist
    public string[] BrainMessages => brainMessageArray;
    [SerializeField] private bool canReply;
    public bool CanReply => canReply;
}
