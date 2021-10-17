using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private float waitOnPickup = 0.2f;
    [SerializeField] private float breakForce = 35f;
    [HideInInspector] private bool pickedUp = false;
    public bool PickedUp { get { return pickedUp; } set { pickedUp = value; } }
    private PlayerPickUpBehaviour playerPickUp;

    private Rigidbody bookRigidbody;
    public Rigidbody BookRigidbody => bookRigidbody;
    private BoxCollider boxCollider;
    public BoxCollider BookCollider => boxCollider;
    public void Interact()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject != this.gameObject)
            return;
        if (!pickedUp)
        {
            playerPickUp.GetPickedupObject(this.gameObject);
        }
        else
        {
            playerPickUp.BreakConnection();
            pickedUp = false;
        } 
    }

    private void Awake()
    {
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();
        bookRigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (pickedUp)
        {
            if(collision.relativeVelocity.magnitude > breakForce)
            {
                playerPickUp.BreakConnection(); 
            }
        }
    }

    //prevent breaking when the player just pickedUp
    public IEnumerator PickUp()
    {
        yield return new WaitForSeconds(waitOnPickup);
        pickedUp = true;
    }
}
