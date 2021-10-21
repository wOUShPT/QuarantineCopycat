using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemBehaviour : MonoBehaviour, IInteractable
{
    public enum PickUpObjectType
    {
        Book, Cloth, Disk, Any
    }
    [SerializeField] private PickUpObjectType objectType;
    public PickUpObjectType ObjectType => objectType;
    [SerializeField] private float waitOnPickup = 0.2f;
    //[SerializeField] private float breakForce = 35f;
    private bool pickedUp = false;
    public bool PickedUp { get { return pickedUp; } set { pickedUp = value; } }
    private PlayerPickUpBehaviour playerPickUp;

    private Rigidbody bookRigidbody;
    public Rigidbody BookRigidbody => bookRigidbody;
    private BoxCollider boxCollider;
    public BoxCollider BookCollider => boxCollider;
    private bool wasInterected = false;
    //Need initial scale
    private Vector3 initialScale;
    public Vector3 InitialScale => initialScale;
    [SerializeField]private BookParams bookParams;
    // Object Type == Book
    [System.Serializable]
    public class BookParams
    {
        [TextArea(2, 20)] public List<string> textList;
    }
    public List<string> TextList => bookParams.textList;
    [SerializeField]private ClothParams clothParams;
    // Object Type == cloth
    [System.Serializable]
    public class ClothParams
    {
        public bool isClean = false;
    }
    //Object Type == disk
    [SerializeField]private DiskParams diskParams;
    [System.Serializable]
    public class DiskParams
    {
        public AudioClip audioClip;
    }
    public AudioClip AudioClip => diskParams.audioClip;

    private void Awake()
    {
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();
        bookRigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        initialScale = new Vector3(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
    }
    public void Interact()
    {
        if (wasInterected)
            return;
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject != this.gameObject)
            return;
        if (!pickedUp)
        {
            PickUp();
        }
        else if( pickedUp && playerPickUp.CurrentlyPickedUpObject != null)
        {
            DropItem();
        }
        wasInterected = true;
    }
    private void PickUp()
    {
        playerPickUp.GetPickedupObject(this.gameObject);
        pickedUp = true;
    }
    private void DropItem()
    {
        playerPickUp.BreakConnection();
        pickedUp = false;
    }
    public void InteractExit()
    {
        if (wasInterected)
        {
            wasInterected = false;
        }
    }
    
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (pickedUp)
    //    {
    //        if(collision.relativeVelocity.magnitude > breakForce)
    //        {
    //            playerPickUp.BreakConnection(); 
    //        }
    //    }
    //}


}
