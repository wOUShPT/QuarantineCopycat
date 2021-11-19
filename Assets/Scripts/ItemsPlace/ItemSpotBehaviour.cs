using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSpotBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] protected float interactionDistance;
    [SerializeField] protected PickUpItemBehaviour.PickUpObjectType dropObjectType;
    public PickUpItemBehaviour.PickUpObjectType DropObjectType => dropObjectType;
    private bool wasInterected = false;
    protected PlayerPickUpBehaviour playerPickUp;
    //Book
    protected PickUpItemBehaviour item;
    public PickUpItemBehaviour Item { get { return item; } set { item = value; } }
    [SerializeField] protected Transform[] childrenItemSpot;
    //delegate
    protected delegate void InteractDelegate();
    protected InteractDelegate interactDelegate;
    protected Stack<ClothParams> clothParamsStack;
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

    [SerializeField] protected Transform[] holderPositionArray;
    
    //Object type == disk
    [SerializeField] protected DiskParams diskParams;
    [System.Serializable]
    public class DiskParams
    {
        public VinylDiskBehaviour diskBehaviour;
        public AudioClip targetMusic;
    }
    //Object type == Bread
    [SerializeField] protected BreadParams breadParams;
    [System.Serializable]
    public class BreadParams
    {
        public BoxCollider InteractionTriggerCollider;
        public BoxCollider BoxCollider;
        public Transform LeftToasterPivot;
        public Transform RightToasterPivot;
        public Transform LeftToast;
        public Transform RightToast;
        public bool IsBreadDoing;
    }
    //Object Type == Coffee Machine
    [SerializeField] protected CoffeeMachineParams coffeeMachineParams;
    [System.Serializable]
    public class CoffeeMachineParams
    {
        public BoxCollider InteractionTriggerCollider;
        public BoxCollider BoxCollider;
        public Transform CoffeePivot;
        public bool IsCoffeeBeDoing;
    }
    //Object type == Plate //clean plates
    protected Stack<PlateSpotParams> plateParamsStack;
    [System.Serializable]
    public class PlateSpotParams
    {
        public Transform holderPosition;
        public PickUpItemBehaviour itemBehaviour;
        //Constructor
        public PlateSpotParams(Transform _holderPosition, PickUpItemBehaviour _itemBehaviour)
        {
            holderPosition = _holderPosition;
            itemBehaviour = _itemBehaviour;
        }
    }
    //Object Type == Fridge
    [SerializeField]protected FridgeParams fridgeParams;
    [System.Serializable]
    public class FridgeParams
    {
        public Transform[] foodTransform;
        public List<PickUpItemBehaviour> foodPickUps;
    }

    protected virtual void Awake() //awake
    {        
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();
        interactDelegate = CheckPlayerHasItem;
    }
    public void ExitInteract()
    {
        wasInterected = false;
    }

    public void Interact()
    {
        if (wasInterected) //already interacted
            return;
        interactDelegate?.Invoke();
        wasInterected = true;
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }
    protected abstract void PlaceItemToSpot();

    protected void SetItemValuesDefault(Transform _item) //Set collider to trigger and rb to kinematic
    {
        _item.localPosition = Vector3.zero;
        _item.localRotation = Quaternion.Euler(Vector3.zero);
    }
    protected abstract void CheckPlayerHasItem();

    protected abstract void TakeItemToPlayer();

    protected Transform GetAvailableSpot()
    {
        Transform chosenSpot = null;
        if(AreSpotsFull())
        {
            return chosenSpot; ;
        }
        foreach (Transform spot in childrenItemSpot)
        {
            if(spot.childCount == 0)
            {
                chosenSpot = spot;
                break;
            }
        }
        return chosenSpot;
    }
    protected bool AreSpotsFull()
    {
        if(childrenItemSpot.Length == 0)
        {
            return false; // If there's not spots
        }
        foreach(Transform spot in childrenItemSpot)
        {
            if( spot.childCount == 0)
            {
                return false;
            }
        }
        return true;
    }

}
