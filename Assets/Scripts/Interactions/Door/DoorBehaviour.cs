using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class DoorBehaviour : InteractableBehaviour
{
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;
    private delegate void DoorsInteraction();
    private DoorsInteraction doorsInteraction;
    private bool _wasInteracted = false;
    private enum RotationAxis
    {
        XAxis, YAxis, ZAxis
    }
    [SerializeField] private RotationAxis rotationAxis;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float openDuration;
    [SerializeField] private float targetRotateGap = 90; // be the target in one axis
    private bool isBeingAnimated = false;
    public EventReference OpenDoorFMODEvent;
    public EventReference CloseDoorFMODEvent;
    private EventInstance _eventInstance;
    public UnityEvent effect;

    protected override void Awake()
    {
        base.Awake();
        doorsInteraction = OpenDoorByCode;
    }
    private void Start()
    {
        _wasInteracted = false;
    }

    public override void Interact()
    {
        if (isBeingAnimated)
        {
            return;
        }
        doorsInteraction?.Invoke();
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
        _eventInstance = FMODUnity.RuntimeManager.CreateInstance(OpenDoorFMODEvent);
        _eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _eventInstance.start();
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
        _eventInstance = FMODUnity.RuntimeManager.CreateInstance(CloseDoorFMODEvent);
        _eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _eventInstance.start();
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
        while ( elapsed < openDuration)
        {
            float percentage = (float)elapsed / openDuration;
            _rotate.rotation = Quaternion.Lerp(_rotate.rotation, to, animationCurve.Evaluate( percentage)); // Call evaluate
            elapsed += Time.deltaTime;
            yield return null;
        }
        _rotate.rotation = to;
        isBeingAnimated = false;
    }
}
