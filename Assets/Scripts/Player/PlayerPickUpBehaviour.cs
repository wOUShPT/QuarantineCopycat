using UnityEngine;

public class PlayerPickUpBehaviour : MonoBehaviour
{
    
    [Header("PickUp")]
    [SerializeField] private Transform pickupParent; // holder parent
    public PickUpItemBehaviour CurrentlyPickedUpObject => pickUpItem;
    private Rigidbody pickUpRB;

    [Header("ObjectFollow")]
    private PickUpItemBehaviour pickUpItem;


    private BookInspection bookInspection;

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
        CheckIsBrushTeethBehaviour();
    }

    public void BreakConnection()
    {
        //Set parent to null
        pickUpItem.transform.SetParent(null);
        pickUpRB.constraints = RigidbodyConstraints.None;
        pickUpRB.isKinematic = false;
        pickUpRB = null;
        pickUpItem.PickedUp = false;
        CheckPlayerWillDropToothBrush();
        pickUpItem = null;
    }
    public void PickUpObject()
    {
        //Make book ( or other objct parent to pickup and move it to default position
        pickUpItem.transform.SetParent(pickupParent);
        pickUpItem.transform.localPosition = Vector3.zero;
        pickUpItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
        pickUpItem.transform.localScale = pickUpItem.InitialScale;
        //assign rigidbody and make it kinematic
        pickUpRB = pickUpItem.ItemRigidbody;
        pickUpRB.constraints = RigidbodyConstraints.FreezeRotation;
        pickUpRB.isKinematic = true;
        pickUpItem.ItemCollider.isTrigger = false;
    }
    private void CheckIsBrushTeethBehaviour()
    {
        if( pickUpItem != null && pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Toothbrush)
        {
            pickUpItem.GetBrushTeethBehaviour.CheckPlayeerHasToothSpecificItem();
        }
        if (pickUpItem != null && pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.WateringCan)
        {
            pickUpItem.WaterPlantsBehaviour.CheckPlayeerHasToothSpecificItem();
        }
        if (pickUpItem != null && pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Plate)
        {
            pickUpItem.PlateBehaviour.CheckPlayeerHasToothSpecificItem();
        }
    }
    private void CheckPlayerWillDropToothBrush()
    {
        if (pickUpItem != null && pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Toothbrush)
        {
            pickUpItem.GetBrushTeethBehaviour.CheckPlayerDropSpecificItem();
        }
        if (pickUpItem != null && pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.WateringCan)
        {
            pickUpItem.WaterPlantsBehaviour.CheckPlayerDropSpecificItem();
        }
        if (pickUpItem != null && pickUpItem.ObjectType == PickUpItemBehaviour.PickUpObjectType.Plate)
        {
            pickUpItem.PlateBehaviour.CheckPlayerDropSpecificItem();
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


}
