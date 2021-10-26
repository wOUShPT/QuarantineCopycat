using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ItemSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionDistance;
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
    //Object type == Cloth
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
    //Object type == disk
    [SerializeField]private DiskParams diskParams;
    [System.Serializable]
    public class DiskParams
    {
        public VinylDiskBehaviour diskBehaviour;
        public AudioClip targetMusic;
    }
    [SerializeField] private BreadParams breadParams;
    [System.Serializable]
    public class BreadParams
    {
        public BoxCollider InteractionTriggerCollider;
        public BoxCollider boxCollider;
        public Transform LeftToasterPivot;
        public Transform RightToasterPivot;
        public Transform LeftToast;
        public Transform RightToast;
        public bool IsBreadDoing;
    }
    // Awake
    private void Awake()
    {
        
        clothParamsStack = new Stack<ClothParams>();
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();      
        switch (dropObjectType)
        {
            case PickUpItemBehaviour.PickUpObjectType.Any: //Book or any
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
            case PickUpItemBehaviour.PickUpObjectType.Bread:
                breadParams.boxCollider = GetComponent<BoxCollider>();
                breadParams.InteractionTriggerCollider.enabled = false;
                breadParams.boxCollider.enabled = true;
                interactDelegate = CheckPlayerHasBread;
                break;
        }
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        if(CheckCanInteract())
        {
            interactDelegate?.Invoke();
            wasInterected = true;
        }
    }
    private bool CheckCanInteract() //Avoid doing multiple times
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
    #region Book or Any
    //Related to book target or any
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
            interactDelegate = TakeItemToPlayer;
        }
    }
    private void PlaceItemToSpot()
    {
        item.transform.SetParent(childrenItemSpot != null ? childrenItemSpot :this.transform );
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.Euler(Vector3.zero);
        item.transform.localScale = item.InitialScale;
        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.isTrigger = true;
    }
    private void TakeItemToPlayer()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {
            //has something
            return;
        }
        // Player took the book or any
        playerPickUp.GetPickedupObject(item.gameObject);
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
    #endregion

    #region Cloth Scripts Related
    //Related Cloth Spot
    private void CheckPlayerHasCloth()
    {
        if( playerPickUp.CurrentlyPickedUpObject == null)
        {
            if (CheckLaundryHasCloths())
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
    private void PlaceClothToCest(PickUpItemBehaviour _pickUpItem) // Set the item droped and put on the stack in the laundry
    {
        _pickUpItem.transform.SetParent(holderPositionArray[clothParamsStack.Count]);
        _pickUpItem.transform.localPosition = Vector3.zero;
        _pickUpItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
        _pickUpItem.transform.localScale = _pickUpItem.InitialScale;
        _pickUpItem.ItemRigidbody.isKinematic = true;
        _pickUpItem.ItemCollider.isTrigger = true;
        clothParamsStack.Push(new ClothParams(holderPositionArray[clothParamsStack.Count],_pickUpItem ));
    }
    
    private void TakeClothFromChest()
    {
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour pickUpItemBehaviour)) // it's a book player has picked
        {
            CheckPlayerHasCloth();
        }
        else // Player took cloth
        {
            ClothParams clothParams = clothParamsStack.Pop();
            clothParams.itemBehaviour.ItemCollider.isTrigger = false;
            clothParams.itemBehaviour.ItemRigidbody.isKinematic = true;
            playerPickUp.GetPickedupObject(clothParams.itemBehaviour.gameObject);
        }
    }
    private bool CheckLaundryHasCloths() //Check the laundry has cloths
    {
        if(clothParamsStack.Count  > 0)
        {
            return true; // has at least one cloth
        }
        return false; // no cloths
    }
    #endregion

    #region Disk
    //Related to disk
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
                interactDelegate = TakeItemToPlayer;
            }
        }
    }
    #endregion

    #region Bread/Toast
    //Related to bread
    private void CheckPlayerHasBread()
    {
        if( playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour pickUpItem))
        {
            if( pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Bread)
            {
                item = pickUpItem;
                item.PickedUp = false;
                playerPickUp.BreakConnection();
                PlaceBreadToMachine();
                //It's doing imediatly maybe needs a courotine
                StartCoroutine(WaitToMakeToastWork());
                interactDelegate = TakeBreadToPlayer;
            }
        }
    }
    private void PlaceBreadToMachine() //Still doing for braid
    {
        breadParams.LeftToast = item.LeftToast;
        breadParams.LeftToast.SetParent(breadParams.LeftToasterPivot);
        SetBreadValues(breadParams.LeftToast);
        breadParams.RightToast = item.RightToast;
        breadParams.RightToast.SetParent(breadParams.RightToasterPivot);
        SetBreadValues(breadParams.RightToast);

        item.ItemRigidbody.isKinematic = true;
        item.ItemCollider.isTrigger = true;
    }
    private void SetBreadValues(Transform _item) //Set collider to trigger and rb to kinematic
    {
        _item.localPosition = Vector3.zero;
        _item.localRotation = Quaternion.Euler(Vector3.zero);
    }
    private void TakeBreadToPlayer()
    {
        if (breadParams.IsBreadDoing)
            return;
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject.TryGetComponent(out PickUpItemBehaviour bookBehaviour)) // it's a book player has picked
        {         
            return; //player has picked up something
        }
        // Player took the book or any
        breadParams.LeftToast.SetParent(item.transform);
        SetBreadValues(breadParams.LeftToast);
        breadParams.LeftToast = null;
        breadParams.RightToast.SetParent(item.transform);
        SetBreadValues(breadParams.RightToast);
        breadParams.RightToast = null;
        playerPickUp.GetPickedupObject(item.gameObject);
        
        item = null;

        interactDelegate = CheckPlayerHasBread;
    }
    public void BreadReady() //30 second has passed by timeline
    {
        breadParams.IsBreadDoing = false;
        breadParams.InteractionTriggerCollider.enabled = false;
    }
    public void ToasterMakingToasts()
    {
        breadParams.IsBreadDoing = true;
        breadParams.InteractionTriggerCollider.enabled = false;
        breadParams.boxCollider.enabled = true;
    }
    IEnumerator WaitToMakeToastWork()
    {
        breadParams.boxCollider.enabled = false;
        yield return new WaitForSeconds(.6f); //Avoid interact immediatly with the toast
        breadParams.InteractionTriggerCollider.enabled = true;
    }
    #endregion
}
