using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemBehaviour : MonoBehaviour, IInteractable
{
    public enum PickUpObjectType
    {
        Book, Cloth, Any
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
    [SerializeField]private ClothParams clothParams;
    // Object Type == cloth
    [System.Serializable]
    public class ClothParams
    {
        [SerializeField] private bool isClean = false;
    }
    public List<string> TextList => bookParams.textList;

    
    public void Interact()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject != this.gameObject)
            return;
        if (!pickedUp)
        {
            playerPickUp.GetPickedupObject(this.gameObject);
            Debug.Log("Pick");
            pickedUp = true;
        }
        else if( pickedUp && playerPickUp.CurrentlyPickedUpObject != null)
        {
            StopAllCoroutines();
            Debug.Log("Break");
            playerPickUp.BreakConnection();
            pickedUp = false;
        } 
    }

    private void Awake()
    {
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();
        bookRigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        initialScale = new Vector3(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
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

    //prevent breaking when the player just pickedUp
    public IEnumerator PickUp()
    {
        yield return new WaitForSeconds(waitOnPickup);
        pickedUp = true;
    }
}
