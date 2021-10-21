using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private PickUpItemBehaviour.PickUpObjectType dropObjectType;
    public PickUpItemBehaviour.PickUpObjectType DropObjectType => dropObjectType;
    private bool wasInterected = false;
    private PlayerPickUpBehaviour playerPickUp;
    //Book
    private PickUpItemBehaviour item;
    [SerializeField]private Transform childrenItemSpot;
    //delegate
    private delegate void InteractDelegate();
    private InteractDelegate interactDelegate;

    private Stack<ClothParams> clothParamsStack;
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
    [SerializeField]private DiskParams diskParams;
    [System.Serializable]
    public class DiskParams
    {
        public VinylDiskBehaviour diskBehaviour;
        public AudioClip targetMusic;
    }
    // Awake
    private void Awake()
    {
        clothParamsStack = new Stack<ClothParams>();
        
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();      
        switch (dropObjectType)
        {
            case PickUpItemBehaviour.PickUpObjectType.Any:
            case PickUpItemBehaviour.PickUpObjectType.Book:
                interactDelegate += CheckPlayerHasBook;
                if (transform.childCount > 0)
                {
                    childrenItemSpot = this.transform.GetChild(0);
                }
                break;
            case PickUpItemBehaviour.PickUpObjectType.Disk:
                if(diskParams.diskBehaviour == null)
                {
                    diskParams.diskBehaviour = GetComponent<VinylDiskBehaviour>();
                }
                interactDelegate = CheckPlayerHasDisk;
                break;
            case PickUpItemBehaviour.PickUpObjectType.Cloth:
                interactDelegate += CheckPlayerHasCloth;
                break;
        }
    }

    public void Interact()
    {
        if(CheckCanInteract())
        {
            interactDelegate?.Invoke();
            wasInterected = true;
        }
    }
    private bool CheckCanInteract()
    {
        if(!wasInterected)
        {
            return true; // can interact
        }
        return false;
    }
    public void ExitInteract()
    {
        if (wasInterected)
        {
            wasInterected = !wasInterected;
        }
    }
    //Related to book target
    private void CheckPlayerHasBook()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            if( bookBehaviour.ObjectType != DropObjectType && DropObjectType != PickUpItemBehaviour.PickUpObjectType.Any)
            {
                return; //can't put an cloth on a book spot
            }
            item = bookBehaviour;
            item.PickedUp = false;
            playerPickUp.BreakConnection(); // Drop book
            PlaceItemToSpot();
            interactDelegate = DisplayOccupiedWarning;
        }
    }
    private void PlaceItemToSpot()
    {
        Debug.Log(item.name);
        item.transform.SetParent(childrenItemSpot != null ? childrenItemSpot :this.transform );
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.Euler(Vector3.zero);
        item.transform.localScale = item.InitialScale;
        item.BookRigidbody.isKinematic = true;
        item.BookCollider.isTrigger = true;
    }
    private void DisplayOccupiedWarning()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            //has something
            Debug.Log("Occupied");
        }
        else // Player took the book
        {
            playerPickUp.GetPickedupObject(item.gameObject);
            item.BookRigidbody.isKinematic = true;
            item.BookCollider.isTrigger = false;
            item = null;
            switch (dropObjectType)
            {
                case PickUpItemBehaviour.PickUpObjectType.Book:
                case PickUpItemBehaviour.PickUpObjectType.Any:
                    interactDelegate = CheckPlayerHasBook;
                    break;
                case PickUpItemBehaviour.PickUpObjectType.Disk:                  
                    //Stop disk vinyl music
                    diskParams.diskBehaviour.StopVinylDisk();
                    diskParams.targetMusic = null;
                    interactDelegate = CheckPlayerHasDisk;
                    break;
            }
        }
    }
    //Related Cloth Spot
    private void CheckPlayerHasCloth()
    {
        if( playerPickUp.CurrentlyPickedUpObject == null)
        {
            if (CheckHasCloths())
            {
                TakeClothFromChest();
            }
            return;
        }
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            if(clothParamsStack.Count >= maxNumberCloths)
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
                PlaceItemToSpot();
            }
        }
    }
    private void PlaceClothToCest(PickUpItemBehaviour _pickUpItem) // Set the item droped and put on the stack
    {
        _pickUpItem.transform.SetParent(holderPositionArray[clothParamsStack.Count]);
        _pickUpItem.transform.localPosition = Vector3.zero;
        _pickUpItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
        _pickUpItem.transform.localScale = _pickUpItem.InitialScale;
        _pickUpItem.BookRigidbody.isKinematic = true;
        _pickUpItem.BookCollider.isTrigger = true;
        clothParamsStack.Push(new ClothParams(holderPositionArray[clothParamsStack.Count],_pickUpItem ));
    }
    
    private void TakeClothFromChest()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour pickUpItemBehaviour)) // it's a book player has picked
        {
            //has something
            Debug.Log("Occupied: Player has" + playerPickUp.CurrentlyPickedUpObject);
            Debug.Log(pickUpItemBehaviour.gameObject.name);
            CheckPlayerHasCloth();
        }
        else // Player took cloth
        {
            ClothParams clothParams = clothParamsStack.Pop();
            clothParams.itemBehaviour.BookCollider.isTrigger = false;
            clothParams.itemBehaviour.BookRigidbody.isKinematic = true;
            playerPickUp.GetPickedupObject(clothParams.itemBehaviour.gameObject);
        }
    }
    private bool CheckHasCloths()
    {
        if(clothParamsStack.Count  > 0)
        {
            return true; // has at least one cloth
        }
        return false; // no cloths
    }
    //Related to cloth
    private void CheckPlayerHasDisk()
    {
        if(playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour pickUpItem))
        {
            if(pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Disk)
            {
                item = pickUpItem;
                item.PickedUp = false;
                playerPickUp.BreakConnection();
                PlaceItemToSpot();
                diskParams.targetMusic = pickUpItem.AudioClip;
                diskParams.diskBehaviour.PlayVinylDisk(diskParams.targetMusic);
                interactDelegate = DisplayOccupiedWarning;
            }
        }
    }
}
