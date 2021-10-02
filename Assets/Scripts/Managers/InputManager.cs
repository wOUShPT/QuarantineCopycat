using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private InputActions _inputActions;
    private PlayerInputStruct _playerInput;
    private MenuInputStruct _menuInput;


    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputActions();
            _inputActions.Player.Movement.performed += ctx => _playerInput.Movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
            _inputActions.Player.Movement.canceled += ctx => _playerInput.Movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
            _inputActions.Player.Look.performed += ctx => _playerInput.Look = ctx.ReadValue<Vector2>();
            _inputActions.Player.Look.canceled += ctx => _playerInput.Look = ctx.ReadValue<Vector2>();
            _inputActions.Player.Interact.performed += ctx => _playerInput.Interaction = ctx.ReadValue<float>();
            _inputActions.Player.Interact.canceled += ctx => _playerInput.Interaction = ctx.ReadValue<float>();
            _inputActions.Player.Pause.performed += ctx => _playerInput.Pause = ctx.ReadValue<float>();
            _inputActions.Player.Pause.canceled += ctx => _playerInput.Pause = ctx.ReadValue<float>();
            
            
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


    public struct PlayerInputStruct
    {
        public Vector3 Movement;
        public Vector2 Look;
        public float Interaction;
        public float Pause;

    }
    
    public struct MenuInputStruct
    {
        public Vector2 Navigation;
        public float Confirm;
        public float Back;
    }

    public PlayerInputStruct PlayerInput => _playerInput;

    public MenuInputStruct MenuInput => _menuInput;
}
