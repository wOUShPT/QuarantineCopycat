using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class PickUpItemBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField]
    private float interactionDistance = 0f;
    protected ItemSpotBehaviour itemSpotBehaviour;
    public ItemSpotBehaviour ItemSpotBehaviour { get { return itemSpotBehaviour; } set { itemSpotBehaviour = value; } }
    public enum PickUpObjectType
    {
        Book, Cloth, Disk, Bread, Any, Coffee, Toothbrush, WateringCan, Plate, Food
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

    private Animator itemAnimator;
    public Animator ItemAnimator => itemAnimator; 
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
        public Transform leftPivot;
        public Transform rightPivot;
    }
    public Transform LeftToast => breadParams.leftToast;
    public Transform RightToast => breadParams.rightToast;
    public Transform LeftBreadPivot => breadParams.leftPivot;
    public Transform RightBreadPivot => breadParams.rightPivot;

    //Object type == Coffee
    [SerializeField]private CoffeeParams coffeeParams;
    [System.Serializable]
    public class CoffeeParams
    {
        public bool isReady;
    }   
    //Object type == Toothbrush
    [SerializeField] private ToothBrushParams brushParams;
    [System.Serializable]
    public class ToothBrushParams
    {
        public BrushingTeethBehaviour teethBehaviour;
        public bool hasToothpaste;
        public Transform toothBrush;
    }
    public BrushingTeethBehaviour GetBrushTeethBehaviour => brushParams.teethBehaviour;

    public bool HasToothpaste { get { return brushParams.hasToothpaste; } set { brushParams.hasToothpaste = value; } }
    //Object type == WateringCan
    [SerializeField] private WateringCanParams wateringCanParams;
    [System.Serializable]
    public class WateringCanParams
    {
        public WaterThePlantsBehaviour plantsBehaviour;
        public ParticleSystem waterParticle;
    }
    public ParticleSystem GetWaterParticle => wateringCanParams.waterParticle;
    public WaterThePlantsBehaviour WaterPlantsBehaviour => wateringCanParams.plantsBehaviour;
    //Object type == plate
    [SerializeField] private PlateParams plateParams;
    [System.Serializable]
    public class PlateParams
    {
        public WashPlateBehaviour plateBehaviour;
        public bool isWashed;
        public bool isPlaced;
    }
    public WashPlateBehaviour PlateBehaviour => plateParams.plateBehaviour;
    public bool IsPlateWashed { get { return plateParams.isWashed; } set { plateParams.isWashed = value; } }
    public bool IsPlatePlaced { get { return plateParams.isPlaced; } set { plateParams.isPlaced = value; } }
    //Object type == food
    [SerializeField] private FoodParams foodParams;
    [System.Serializable]
    public class FoodParams
    {
        public bool isPickable;
        public bool hasEaten;
    }
    public bool IsPickable { get { return foodParams.isPickable; } set { foodParams.isPickable = value; } }
    public bool HasEaten { get { return foodParams.hasEaten; } set { foodParams.hasEaten = value; } }
    private void Awake()
    {
        playerPickUp = FindObjectOfType<PlayerPickUpBehaviour>();
        itemRigidbody = GetComponent<Rigidbody>();
        itemCollider = GetComponent<BoxCollider>();
        itemAnimator = GetComponent<Animator>();
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
        if (playerPickUp.CurrentlyPickedUpObject != null && playerPickUp.CurrentlyPickedUpObject != this)
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
        playerPickUp.GetPickedupObject(this);
        pickedUp = true;
        //Desattach itemspot to this item and vice versa
        if(ItemSpotBehaviour != null)
        {
            itemSpotBehaviour.Item = null;
            itemSpotBehaviour = null;
        }
    }
    private void DropItem()
    {
        playerPickUp.BreakConnection();
        pickedUp = false;
    }
    public void ExitInteract()
    {
        wasInterected = false;
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
