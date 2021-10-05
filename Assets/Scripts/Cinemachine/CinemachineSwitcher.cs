using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction inputAction;
    private Animator animator;
    private enum CinemachineStateSwitcher
    {
        FirstPerson, SecondPerson
    }
    private CinemachineStateSwitcher cinemachineSwitcher;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputAction.performed += _ => SwitchState(); 
    }
    private void SwitchState()
    {
        cinemachineSwitcher++;
        if((int)cinemachineSwitcher >= Enum.GetNames(typeof(CinemachineStateSwitcher)).Length) // In case cinemachine is beyond outside of index
        {
            cinemachineSwitcher = 0;
        }
        switch (cinemachineSwitcher)
        {
            case CinemachineStateSwitcher.FirstPerson:
                animator.Play("FPCameraState");
                break;
            case CinemachineStateSwitcher.SecondPerson:
                animator.Play("SPCameraState");
                break;
        }
    }
}
