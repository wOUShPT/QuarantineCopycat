using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;
    private delegate void DoorsInteraction();
    private DoorsInteraction doorsInteraction;
    private bool wasInteracted = false;
    [SerializeField] private AnimationCurve animationCurve;
    private enum RotationAxis
    {
        XAxis, YAxis, ZAxis
    }
    [SerializeField] private RotationAxis rotationAxis;
    [SerializeField] private float targetRotateGap = 90; // be the target in one axis
    private bool isBeingAnimated = false;

    private enum DoorType
    {
        Cabinet, Fridge
    }
    [SerializeField] private DoorType doorType;
    private FridgePlace fridgePlace;
    protected int interactionLayer;
    [SerializeField] protected int outlineLayer = 11;
    [SerializeField] protected OtherGameobjectOutline[] otherGameobjectOutlineArray;
    [System.Serializable]
    public class OtherGameobjectOutline
    {
        public GameObject outlineObject;
        public int interactionTrigger;
    }
    private void Awake()
    {
        doorsInteraction = OpenDoorByCode;
        interactionLayer = gameObject.layer;
        if (otherGameobjectOutlineArray.Length != 0)
        {
            foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
            {
                outlineObject.interactionTrigger = outlineObject.outlineObject.layer;
            }
        }
    }
    private void Start()
    {
        if(doorType == DoorType.Fridge) //If it's a fridge
        {
            fridgePlace = GetComponentInChildren<FridgePlace>();
            fridgePlace.enabled = false;
        }
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        if (wasInteracted || isBeingAnimated)
        {
            return;
        }
        doorsInteraction?.Invoke();
        wasInteracted = true;
    }
    public void ExitInteract()
    {
        wasInteracted = false;
        gameObject.layer = interactionLayer;
        if (otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = outlineObject.interactionTrigger;
        }
    }
    private void OpenDoorByCode()
    {
        if(leftDoor != null)
        {
            switch (rotationAxis)
            {
                case RotationAxis.XAxis:
                    RotateDoor(leftDoor, new Vector3(targetRotateGap, 0f, 0f));
                    break;
                case RotationAxis.YAxis:
                    RotateDoor(leftDoor, new Vector3(0f, targetRotateGap, 0f));
                    break;
                case RotationAxis.ZAxis:
                    RotateDoor(leftDoor, new Vector3(0f, 0f, targetRotateGap));
                    break;
                default:
                    break;
            }
        }
        if( rightDoor != null)
        {
            switch (rotationAxis)
            {
                case RotationAxis.XAxis:
                    RotateDoor(rightDoor, new Vector3(-targetRotateGap, 0f, 0f));
                    break;
                case RotationAxis.YAxis:
                    RotateDoor(rightDoor, new Vector3(0f, -targetRotateGap, 0f));
                    break;
                case RotationAxis.ZAxis:
                    RotateDoor(rightDoor, new Vector3(0f, 0f, -targetRotateGap));
                    break;
                default:
                    break;
            }
        }
        CheckIsFridgeOpen();
        doorsInteraction = CloseDoorByCode;
    }
    private void CloseDoorByCode()
    {
        if (leftDoor != null)
        {
            switch (rotationAxis)
            {
                case RotationAxis.XAxis:
                    RotateDoor(leftDoor, new Vector3(-targetRotateGap, 0f, 0f));
                    break;
                case RotationAxis.YAxis:
                    RotateDoor(leftDoor, new Vector3(0f, -targetRotateGap, 0f));
                    break;
                case RotationAxis.ZAxis:
                    RotateDoor(leftDoor, new Vector3(0f, 0f, -targetRotateGap));
                    break;
                default:
                    break;
            }
        }
        if(rightDoor != null)
        {
            switch (rotationAxis)
            {
                case RotationAxis.XAxis:
                    RotateDoor(rightDoor, new Vector3(targetRotateGap, 0f, 0f));
                    break;
                case RotationAxis.YAxis:
                    RotateDoor(rightDoor, new Vector3(0f, targetRotateGap, 0f));
                    break;
                case RotationAxis.ZAxis:
                    RotateDoor(rightDoor, new Vector3(0f, 0f, targetRotateGap));
                    break;
                default:
                    break;
            }
        }
        doorsInteraction = OpenDoorByCode;
    }
    private void RotateDoor(Transform _rotate, Vector3 _rotationVector)
    {
        StartCoroutine(Rotating( _rotate, _rotationVector, 3f));
    }
    IEnumerator Rotating(Transform _rotate, Vector3 targetVector, float _time)
    {
        float elapsed = 0.0f; //elaped
        isBeingAnimated = true;
        Quaternion to = _rotate.rotation * Quaternion.Euler(targetVector);
        while ( elapsed < _time)
        {
            float percentage = (float)elapsed / _time;
            _rotate.rotation = Quaternion.Lerp(_rotate.rotation, to, animationCurve.Evaluate( percentage)); // Call evaluate
            elapsed += Time.deltaTime;
            yield return null;
        }
        _rotate.rotation = to;
        isBeingAnimated = false;
    }
    private void CheckIsFridgeOpen()
    {
        if(doorType != DoorType.Fridge)
        {
            return;
        }
        fridgePlace.enabled = true;
        //foreach( PickUpItemBehaviour pickups in foodPickUps)
        //{
        //    pickups.IsPickable = true;
        //}
    }
    public void DisplayOutline()
    {
        if (gameObject.layer == outlineLayer)
            return;
        gameObject.layer = outlineLayer;
        if (otherGameobjectOutlineArray.Length == 0)
            return;
        foreach (OtherGameobjectOutline outlineObject in otherGameobjectOutlineArray)
        {
            outlineObject.outlineObject.layer = outlineLayer;
        }
    }
}
