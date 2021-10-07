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
    private CinemachineFPExtension fPExtension;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        fPExtension = FindObjectOfType<CinemachineFPExtension>();
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
        inputAction.performed += _ => ChangeToSecond(); 
    }
    public void ChangeToFirst()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.FirstPerson;
        SwitchState();
    }
    public void ChangeToSecond()
    {
        cinemachineSwitcher = CinemachineStateSwitcher.SecondPerson;
        SwitchState();
    }
    
    private void SwitchState()
    {
        switch (cinemachineSwitcher)
        {
            case CinemachineStateSwitcher.FirstPerson:
                animator.Play("FPCameraState");
                fPExtension.IsFirstPerson = true;
                break;
            case CinemachineStateSwitcher.SecondPerson:
                animator.Play("SPCameraState");
                fPExtension.IsFirstPerson = false;
                break;
        }
    }
}
