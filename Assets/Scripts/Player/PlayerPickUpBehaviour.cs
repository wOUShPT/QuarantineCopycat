using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpBehaviour : MonoBehaviour
{
    
    [Header("PickUp")]
    [SerializeField] private Transform pickupParent; // holder parent
    [SerializeField] private GameObject currentlyPickedUpObject;
    public GameObject CurrentlyPickedUpObject => currentlyPickedUpObject;
    private Rigidbody pickUpRB;

    [Header("ObjectFollow")]
    private PickUpItemBehaviour bookBehaviour;


    private BookInspection bookInspection;
    private void Awake()
    {
        InputManager.Instance.ToggleInspectionControls(false);
        bookInspection = FindObjectOfType<BookInspection>();
        bookInspection.HideBook();
    }
    public void GetPickedupObject(GameObject pickedupObject)
    {
        currentlyPickedUpObject = pickedupObject;
        PickUpObject();
    }

    public void BreakConnection()
    {
        //Set parent to null
        currentlyPickedUpObject.transform.SetParent(null);
        pickUpRB.constraints = RigidbodyConstraints.None;
        pickUpRB.isKinematic = false;
        pickUpRB = null;
        currentlyPickedUpObject = null;
        bookBehaviour.PickedUp = false;
    }
    public void PickUpObject()
    {
        //Make book ( or other objct parent to pickup and move it to default position
        currentlyPickedUpObject.transform.SetParent(pickupParent);
        currentlyPickedUpObject.transform.localPosition = Vector3.zero;
        currentlyPickedUpObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        currentlyPickedUpObject.transform.localScale = currentlyPickedUpObject.GetComponent<PickUpItemBehaviour>().InitialScale;

        bookBehaviour = currentlyPickedUpObject.GetComponent<PickUpItemBehaviour>();
        //assign rigidbody and make it kinematic
        pickUpRB = bookBehaviour.BookRigidbody;
        pickUpRB.constraints = RigidbodyConstraints.FreezeRotation;
        pickUpRB.isKinematic = true;
    }
    private void Update()
    {
        if (currentlyPickedUpObject != null && bookBehaviour.ObjectType == PickUpItemBehaviour.PickUpObjectType.Book && InputManager.Instance.PlayerInput.Inspection)
        {
            bookInspection.SetTextArray(bookBehaviour.TextList);
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
