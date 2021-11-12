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
    private enum RotationAxis
    {
        XAxis, YAxis, ZAxis
    }
    [SerializeField] private RotationAxis rotationAxis;
    [SerializeField] private float targetRotateGap = 90; // be the target in one axis

    private void Awake()
    {
        doorsInteraction = OpenDoorByCode;
    }

    public float InteractionDistance()
    {
        return interactionDistance;
    }

    public void Interact()
    {
        if (wasInteracted)
        {
            return;
        }
        doorsInteraction?.Invoke();
        wasInteracted = true;
    }
    public void ExitInteract()
    {
        wasInteracted = false;
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
        StartCoroutine(Rotating( _rotate, _rotationVector, 1));
    }
    IEnumerator Rotating(Transform _rotate, Vector3 targetVector, float _time)
    {
        float timerCounter = 0.0f;
        Quaternion to = _rotate.rotation * Quaternion.Euler(targetVector);
        while ( timerCounter < _time)
        {
            _rotate.rotation = Quaternion.Slerp(_rotate.rotation, to, timerCounter / _time);
            timerCounter += Time.deltaTime;
            yield return null;
        }
        _rotate.rotation = to;
    }
}
