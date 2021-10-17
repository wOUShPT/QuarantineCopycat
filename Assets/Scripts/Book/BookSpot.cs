using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpot : MonoBehaviour, IInteractable
{
    private PlayerPickUpBehaviour playerPickUp;
    private BoxCollider boxCollider;
    private BookBehaviour book;

    //delegate
    private delegate void InteractDelegate();
    private InteractDelegate interactDelegate;
    // Awake
    private void Awake()
    {
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();
        boxCollider = GetComponent<BoxCollider>();
        interactDelegate += CheckHasBook;
    }

    public void Interact()
    {
        interactDelegate?.Invoke();
    }
    private void CheckHasBook()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out BookBehaviour bookBehaviour)) // it's a book player has picked
        {
            book = bookBehaviour;
            playerPickUp.BreakConnection(); // Drop book
            PlaceBookToSpot();
            interactDelegate -= CheckHasBook;
            interactDelegate += DisplayOccupiedWarning;
        }
    }
    private void PlaceBookToSpot()
    {
        book.transform.SetParent(this.transform);
        book.transform.localPosition = Vector3.zero;
        book.transform.localRotation = Quaternion.Euler(Vector3.zero);
        book.BookRigidbody.isKinematic = true;
        book.BookCollider.isTrigger = true;
    }
    private void DisplayOccupiedWarning()
    {
        Debug.Log("Occupied");
    }
    
}
