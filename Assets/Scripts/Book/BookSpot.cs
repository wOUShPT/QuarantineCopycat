using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private PickUpItemBehaviour.PickUpObjectType dropObjectType;
    public PickUpItemBehaviour.PickUpObjectType DropObjectType => dropObjectType; 
    private PlayerPickUpBehaviour playerPickUp;
    //Book
    private PickUpItemBehaviour book;
    [SerializeField]private Transform childrenItemSpot;
    
    //delegate
    private delegate void InteractDelegate();
    private InteractDelegate interactDelegate;

    private ClothParams[] clothParamsArray;
    private Stack<ClothParams> clothParamsQueue;
    //Cloth
    [System.Serializable]
    public class ClothParams
    {
        public Transform holderPosition;
        public PickUpItemBehaviour itemBehaviour;
        //Constructor
        public ClothParams(Transform _holderPosition, PickUpItemBehaviour _itemBehaviour)
        {
            holderPosition = _holderPosition;
            itemBehaviour = _itemBehaviour;
        }
        
    }
    [SerializeField]private Transform[] holderPositionArray;
    [SerializeField] private int maxNumberCloths = 3;
    // Awake
    private void Awake()
    {
        clothParamsQueue = new Stack<ClothParams>();
        
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();
       
        
        switch (dropObjectType)
        {
            case PickUpItemBehaviour.PickUpObjectType.Any:
                interactDelegate += CheckPlayerHasBook;
                if (transform.childCount > 0)
                {
                    childrenItemSpot = this.transform.GetChild(0);
                }
                break;
            case PickUpItemBehaviour.PickUpObjectType.Book:
                interactDelegate += CheckPlayerHasBook;
                if (transform.childCount > 0)
                {
                    childrenItemSpot = this.transform.GetChild(0);
                }
                break;
            case PickUpItemBehaviour.PickUpObjectType.Cloth:
                interactDelegate += CheckPlayerHasCloth;

                break;
        }
    }

    public void Interact()
    {
        interactDelegate?.Invoke();
    }
    private void CheckPlayerHasBook()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            if( bookBehaviour.ObjectType != DropObjectType && DropObjectType != PickUpItemBehaviour.PickUpObjectType.Any)
            {
                return; //can't put an cloth on a book spot
            }
            book = bookBehaviour;
            book.PickedUp = false;
            playerPickUp.BreakConnection(); // Drop book
            PlaceBookToSpot();
            interactDelegate -= CheckPlayerHasBook;
            interactDelegate += DisplayOccupiedWarning;
        }
    }
    private void PlaceBookToSpot()
    {

        book.transform.SetParent(childrenItemSpot != null ? childrenItemSpot :this.transform );
        book.transform.localPosition = Vector3.zero;
        book.transform.localRotation = Quaternion.Euler(Vector3.zero);
        book.transform.localScale = book.InitialScale;
        book.BookRigidbody.isKinematic = true;
        book.BookCollider.isTrigger = true;
    }
    private void CheckPlayerHasCloth()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            if(clothParamsQueue.Count >= maxNumberCloths)
            {
                return;
            }
            if (bookBehaviour.ObjectType != DropObjectType && DropObjectType != PickUpItemBehaviour.PickUpObjectType.Any)
            {
                return; //can't put an cloth on a book spot
            }
            bookBehaviour.PickedUp = false;
            playerPickUp.BreakConnection(); // Drop book
            if( DropObjectType == PickUpItemBehaviour.PickUpObjectType.Cloth)
            {
                PlaceClothToCest(bookBehaviour);
            }
            else
            {
                PlaceBookToSpot();
            }

            interactDelegate -= CheckPlayerHasCloth;
            interactDelegate += TakeClothFromChest;
        }
    }
    private void PlaceClothToCest(PickUpItemBehaviour _pickUpItem)
    {
        _pickUpItem.transform.SetParent(holderPositionArray[clothParamsQueue.Count]);
        _pickUpItem.transform.localPosition = Vector3.zero;
        _pickUpItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
        _pickUpItem.transform.localScale = _pickUpItem.InitialScale;
        _pickUpItem.BookRigidbody.isKinematic = true;
        _pickUpItem.BookCollider.isTrigger = true;
        clothParamsQueue.Push(new ClothParams(holderPositionArray[clothParamsQueue.Count],_pickUpItem ));
        
    }
    private void DisplayOccupiedWarning()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            //has book
            Debug.Log("Occupied");
        }
        else // Player took the book
        {
            playerPickUp.GetPickedupObject(book.gameObject);
            book = null;
            interactDelegate += CheckPlayerHasBook;
            interactDelegate -= DisplayOccupiedWarning;
        }
    }
    private void TakeClothFromChest()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null) // it's a book player has picked
        {
            //has book
            Debug.Log("Occupied");
        }
        else // Player took the book
        {
            ClothParams clothParams = clothParamsQueue.Pop();
            playerPickUp.GetPickedupObject(clothParams.itemBehaviour.gameObject);
            interactDelegate += CheckPlayerHasCloth;
            interactDelegate -= TakeClothFromChest;
        }
    }    
}
