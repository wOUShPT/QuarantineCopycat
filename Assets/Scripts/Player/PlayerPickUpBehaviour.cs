using UnityEngine;

public class PlayerPickUpBehaviour : MonoBehaviour
{
    
    [Header("PickUp")]
    [SerializeField] private Transform pickupParent; // holder parent

    [Header("ObjectFollow")]
    private PickUpItemBehaviour pickUpItem;


    private BookInspection bookInspection;

    private Inventory inventory;
    private UI_Inventory uiInventory;
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory = FindObjectOfType<UI_Inventory>();
        uiInventory.SetInventory(inventory);
    }
    private void Start()
    {
        InputManager.Instance.ToggleInspectionControls(false);
        pickUpItem = null;
        bookInspection = FindObjectOfType<BookInspection>();
        bookInspection.HideBook();
    }
    public void GetPickedupObject(PickUpItemBehaviour pickedupObject)
    {
        pickUpItem = pickedupObject;
        PickUpObject();
        CheckIsBrushTeethBehaviour(pickedupObject);
    }

    public void BreakConnection(PickUpItemBehaviour item)
    {
        //Set parent to null
        item.transform.SetParent(null);
        item.PickedUp = false;
        CheckPlayerWillDropToothBrush(item);
        pickUpItem = null;
    }
    public void PickUpObject()
    {
        //Make book ( or other objct parent to pickup and move it to default position
        pickUpItem.transform.SetParent(pickupParent);
        pickUpItem.transform.localPosition = Vector3.zero;
        pickUpItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
        pickUpItem.transform.localScale = pickUpItem.InitialScale;
        pickUpItem.gameObject.SetActive(false);
        inventory.AddItem(pickUpItem);
        pickUpItem = null;
    }
    private void CheckIsBrushTeethBehaviour(PickUpItemBehaviour item)
    {
        if(item != null)
        {
            switch (item.ObjectType)
            {
                case PickUpItemBehaviour.PickUpObjectType.Book:
                case PickUpItemBehaviour.PickUpObjectType.Cloth:
                case PickUpItemBehaviour.PickUpObjectType.Disk:
                case PickUpItemBehaviour.PickUpObjectType.Bread:
                case PickUpItemBehaviour.PickUpObjectType.Any:
                case PickUpItemBehaviour.PickUpObjectType.Coffee:
                case PickUpItemBehaviour.PickUpObjectType.Food:
                case PickUpItemBehaviour.PickUpObjectType.Toothbrush:
                    break;
                case PickUpItemBehaviour.PickUpObjectType.WateringCan:
                    item.WaterPlantsBehaviour.CheckPlayeerHasToothSpecificItem();
                    break;
                case PickUpItemBehaviour.PickUpObjectType.Plate:
                    item.PlateBehaviour.CheckPlayeerHasToothSpecificItem();
                    break;
                default:
                    break;
            }
        }
    }
    private void CheckPlayerWillDropToothBrush(PickUpItemBehaviour item)
    {
        if (item != null)
        {
            switch (item.ObjectType)
            {
                case PickUpItemBehaviour.PickUpObjectType.Book:
                case PickUpItemBehaviour.PickUpObjectType.Cloth:
                case PickUpItemBehaviour.PickUpObjectType.Disk:
                case PickUpItemBehaviour.PickUpObjectType.Bread:
                case PickUpItemBehaviour.PickUpObjectType.Any:
                case PickUpItemBehaviour.PickUpObjectType.Coffee:
                case PickUpItemBehaviour.PickUpObjectType.Food:
                case PickUpItemBehaviour.PickUpObjectType.Toothbrush:
                    break;
                case PickUpItemBehaviour.PickUpObjectType.WateringCan:
                    item.WaterPlantsBehaviour.CheckPlayerDropSpecificItem();
                    break;
                case PickUpItemBehaviour.PickUpObjectType.Plate:
                    item.PlateBehaviour.CheckPlayerDropSpecificItem();
                    break;
                default:
                    break;
            }
            
        }
    }
    private void Update()
    {
        if (pickUpItem != null && pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Book && InputManager.Instance.PlayerInput.Inspection)
        {
            // If player has a book
            bookInspection.SetTextArray(pickUpItem.TextList);
            bookInspection.DisplayBook();
            InputManager.Instance.ToggleInspectionControls(true);
            InputManager.Instance.TogglePlayerControls(false);
        }
    }
    public void DisableInspectionControl()
    {
        InputManager.Instance.TogglePlayerControls(true);
        InputManager.Instance.ToggleInspectionControls(false);
    }
    public Inventory GetInventory()
    {
        return inventory;
    }


}
