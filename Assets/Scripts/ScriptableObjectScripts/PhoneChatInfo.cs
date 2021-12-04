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
    Queue<string> otherMessageQueu;
    public Queue<string> OtherMessageArray => otherMessageQueu;
    [TextArea(2, 8)]
    [SerializeField] private string[] brainMessageArray; //arrays to convert t queues
    private Queue<string> brainMessagequeue; // protagonist's message
    public Queue<string> BrainMessages => brainMessagequeue;
    [SerializeField] private bool canReply;
    public bool CanReply { get { return canReply; } set { canReply = value; } }
    [SerializeField] private int chatIndex;
    public int ChatIndex => chatIndex;
    private void OnEnable()
    {
        otherMessageQueu = new Queue<string>();
        brainMessagequeue = new Queue<string>();
        foreach (string stringFromArray in otherMessageArray)
        {
            otherMessageQueu.Enqueue(stringFromArray);
        }
        foreach (string stringFromArray in brainMessageArray)
        {
            brainMessagequeue.Enqueue(stringFromArray);
        }
    }
    private void OnDisable()
    {
        otherMessageQueu.Clear();
        brainMessagequeue.Clear();
    }
}
