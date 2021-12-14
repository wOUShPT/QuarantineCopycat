using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private InputActions _inputActions;
    private PlayerInputStruct _playerInput;
    private MenuInputStruct _menuInput;
    private PhoneInputStruct _phoneInput;
    private InspectionInputStruct _inspectionInput;


    private void Awake()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputActions();
            _inputActions.Player.Movement.performed += ctx => _playerInput.Movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
            _inputActions.Player.Movement.canceled += ctx => _playerInput.Movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
            _inputActions.Player.Look.performed += ctx => _playerInput.Look = ctx.ReadValue<Vector2>();
            _inputActions.Player.Look.canceled += ctx => _playerInput.Look = ctx.ReadValue<Vector2>();
            _inputActions.Player.Interact.performed += ctx => _playerInput.Interaction = true;
            _inputActions.Player.Interact.canceled += ctx => _playerInput.Interaction = false;
            _inputActions.Player.ExitInteraction.performed += ctx => _playerInput.ExitInteraction = true;
            _inputActions.Player.ExitInteraction.canceled += ctx => _playerInput.ExitInteraction = false;
            _playerInput.Shoot = new HoldButton();
            _playerInput.Shoot.phase = _inputActions.Player.ShootIn.phase;
            _inputActions.Player.ShootIn.started += ctx =>
            {
                _playerInput.Shoot.hasStarted = true; ;
                _playerInput.Shoot.isDone = false;
                _playerInput.Shoot.startTime = (float)ctx.time;
                _playerInput.Shoot.holdTime = 0;
            };
            _inputActions.Player.ShootIn.performed += ctx => 
            {
                _playerInput.Shoot.hasStarted = false;
                _playerInput.Shoot.isDone = true;
                _playerInput.Shoot.holdTime = (float) (ctx.time - _playerInput.Shoot.startTime);
                _playerInput.Shoot.startTime = (float)ctx.time;
            };
            
            

            _inputActions.Player.Pause.performed += ctx => _playerInput.Pause = ctx.ReadValue<float>();
            _inputActions.Player.Pause.canceled += ctx => _playerInput.Pause = ctx.ReadValue<float>();
            _inputActions.Player.UsePhone.performed += ctx => _playerInput.UsePhone = ctx.ReadValue<float>();
            _inputActions.Player.UsePhone.canceled += ctx => _playerInput.UsePhone = ctx.ReadValue<float>();
            _inputActions.Player.SwitchChannels.performed += ctx => _playerInput.SwitchTvChannel = ctx.ReadValue<float>();
            _inputActions.Player.SwitchChannels.canceled += ctx => _playerInput.SwitchTvChannel = ctx.ReadValue<float>();
            _inputActions.Player.SwitchChannelVolume.performed += ctx => _playerInput.SwitchTvVolume = ctx.ReadValue<float>();
            _inputActions.Player.SwitchChannelVolume.canceled += ctx => _playerInput.SwitchTvVolume= ctx.ReadValue<float>();
            _inputActions.Player.TapNote.performed += ctx => _playerInput.TapNote = ctx.ReadValue<float>();
            _inputActions.Player.Inspection.performed += ctx => _playerInput.Inspection = true;
            _inputActions.Player.Inspection.canceled += ctx => _playerInput.Inspection = false;

            //Phone
            _inputActions.Phone.Movement.performed += ctx => _phoneInput.Navigation = ctx.ReadValue<Vector2>();
            _inputActions.Phone.Movement.canceled += ctx => _phoneInput.Navigation = ctx.ReadValue<Vector2>();
            _inputActions.Phone.Select.performed += ctx => _phoneInput.Select = ctx.ReadValue<float>();
            _inputActions.Phone.Select.canceled += ctx => _phoneInput.Select = ctx.ReadValue<float>();
            _inputActions.Phone.Return.performed += ctx => _phoneInput.Return = true;
            _inputActions.Phone.Return.canceled += ctx => _phoneInput.Return = false;
            _inputActions.Phone.Send.performed += ctx => _phoneInput.Send = true;
            
            _inputActions.Phone.Send.canceled += ctx => _phoneInput.Send = false;
            _inputActions.Phone.RecieveMessageDebug.performed += ctx => _phoneInput.clickedDebug = true;
            _inputActions.Phone.RecieveMessageDebug.canceled += ctx => _phoneInput.clickedDebug = false;

            _inputActions.Inspection.CancelInspection.performed += ctx => _inspectionInput.CancelInspection = true;
            _inputActions.Inspection.CancelInspection.canceled += ctx => _inspectionInput.CancelInspection = false;
            _inputActions.Inspection.Movement.performed += ctx => _inspectionInput.TurnPage = ctx.ReadValue<float>();
            _inputActions.Inspection.Movement.canceled += ctx => _inspectionInput.TurnPage = ctx.ReadValue<float>();

            _inputActions.Menus.Navigation.performed += ctx => _menuInput.Navigation = ctx.ReadValue<Vector2>();
            _inputActions.Menus.Navigation.canceled += ctx => _menuInput.Navigation = ctx.ReadValue<Vector2>();
            _inputActions.Menus.Confirm.performed += ctx => _menuInput.Confirm = ctx.ReadValue<float>();
            _inputActions.Menus.Confirm.canceled += ctx => _menuInput.Confirm = ctx.ReadValue<float>();
            _inputActions.Menus.Back.performed += ctx => _menuInput.Back = ctx.ReadValue<float>();
            _inputActions.Menus.Back.canceled += ctx => _menuInput.Back = ctx.ReadValue<float>();
        }
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void TogglePlayerControls(bool state)
    {
        if (state)
        {
            _inputActions.Player.Enable();
        }
        else
        {
            _inputActions.Player.Disable();
        }
    }
    
    public void ToggleMenusControls(bool state)
    {
        if (state)
        {
            _inputActions.Menus.Enable();
        }
        else
        {
            _inputActions.Menus.Disable();
        }
    }
    
    public void ToggleDebugControls(bool state)
    {
        if (state)
        {
            _inputActions.DEBUG.Enable();
        }
        else
        {
            _inputActions.DEBUG.Disable();
        }
    }

    public void TogglePhoneControls(bool state)
    {
        if (state)
        {
            _inputActions.Phone.Enable();
        }
        else
        {
            _inputActions.Phone.Disable();
        }
    }

    public void ToggleInspectionControls(bool state)
    {
        if (state)
        {
            _inputActions.Inspection.Enable();
        }
        else
        {
            _inputActions.Inspection.Disable();
        }
    }


    public struct PlayerInputStruct
    {
        public Vector3 Movement;
        public Vector2 Look;
        public bool Interaction;
        public bool ExitInteraction;
        public bool Inspection;
        public HoldButton Shoot;
        public float Pause;
        public float UsePhone;
        public float SwitchTvChannel;
        public float SwitchTvVolume;
        public float TapNote;

    }

    public struct HoldButton
    {
        public bool hasStarted;
        public InputActionPhase phase;
        public bool isDone;
        public float startTime;
        public float holdTime;
    }
    

    public struct PhoneInputStruct
    {
        public Vector2 Navigation;
        public float Select;
        public bool Return;
        public bool Send;
        public bool clickedDebug;
    }
    
    public struct MenuInputStruct
    {
        public Vector2 Navigation;
        public float Confirm;
        public float Back;
    }
    public struct InspectionInputStruct
    {
        public bool CancelInspection;
        public float TurnPage;
    }

    private async Task<bool> SetFalse()
    {
        await Task.Delay((int) (0.1f * 1000f));
        return false;
    }

    public PlayerInputStruct PlayerInput => _playerInput;

    public MenuInputStruct MenuInput => _menuInput;

    public PhoneInputStruct PhoneInput => _phoneInput;

    public InspectionInputStruct InspectionInput => _inspectionInput;
}
