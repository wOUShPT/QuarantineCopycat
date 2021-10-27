using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickUpItemBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField]
    private float interactionDistance;
    public enum PickUpObjectType
    {
        Book, Cloth, Disk, Bread, Any, Coffee
    }
    [SerializeField] private PickUpObjectType objectType;
    public PickUpObjectType ObjectType => objectType;
    //[SerializeField] private float breakForce = 35f;
    private bool pickedUp = false;
    public bool PickedUp { get { return pickedUp; } set { pickedUp = value; } }
    private PlayerPickUpBehaviour playerPickUp;

    private Rigidbody itemRigidbody;
    public Rigidbody ItemRigidbody => itemRigidbody;
    private BoxCollider itemCollider;
    public BoxCollider ItemCollider => itemCollider;
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
    //Object type == Beard
    [SerializeField] private BreadParams breadParams;
    [System.Serializable]
    public class BreadParams
    {
        public bool isReady = false;
        public Transform leftToast;
        public Transform rightToast;
    }
    public Transform LeftToast => breadParams.leftToast;
    public Transform RightToast => breadParams.rightToast;

    //Object type == Coffee
    [SerializeField]private CoffeeParams coffeeParams;
    [System.Serializable]
    public class CoffeeParams
    {
        public bool isReady;
    }
    private void Awake()
    {
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();
        itemRigidbody = GetComponent<Rigidbody>();
        itemCollider = GetComponent<BoxCollider>();
        initialScale = new Vector3(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
    }

    public float InteractionDistance()
    {
        return interactionDistance;
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
    public void ExitInteract()
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
