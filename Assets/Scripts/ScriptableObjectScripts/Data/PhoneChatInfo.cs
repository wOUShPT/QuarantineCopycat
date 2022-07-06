using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Chat Info")]
public class PhoneChatInfo : ScriptableObject
{
    [SerializeField]private new string name;// name the person we're talking
    public string Name => name;
    [TextArea(2, 8)]
    [SerializeField]private string[] otherMessageArray;
    Queue<string> otherMessageQueue;
    public Queue<string> OtherMessageArray => otherMessageQueue;
    [TextArea(2, 8)]
    [SerializeField] private string[] brainMessageArray; //arrays to convert t queues
    private Queue<string> brainMessageQueue; // protagonist's message
    public Queue<string> BrainMessages => brainMessageQueue;
    [SerializeField] private bool canReply;
    public bool CanReply { get { return canReply; } set { canReply = value; } }
    [SerializeField] private int chatIndex;
    public int ChatIndex => chatIndex;
    private void OnEnable()
    {
        otherMessageQueue = new Queue<string>();
        brainMessageQueue = new Queue<string>();
        foreach (string stringFromArray in otherMessageArray)
        {
            otherMessageQueue.Enqueue(stringFromArray);
        }
        foreach (string stringFromArray in brainMessageArray)
        {
            brainMessageQueue.Enqueue(stringFromArray);
        }
    }
    private void OnDisable()
    {
        otherMessageQueue.Clear();
        brainMessageQueue.Clear();
    }
}
