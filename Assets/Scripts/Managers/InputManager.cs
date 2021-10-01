using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private InputActions _inputActions;
    private PlayerInputStruct m_playerInput;
    private MenuInputStruct m_menuInput;


    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputActions();
            _inputActions.Player.Movement.performed += ctx => m_playerInput.Movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
            _inputActions.Player.Movement.canceled += ctx => m_playerInput.Movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
            _inputActions.Player.Look.performed += ctx => m_playerInput.Look = ctx.ReadValue<Vector2>();
            _inputActions.Player.Look.canceled += ctx => m_playerInput.Look = ctx.ReadValue<Vector2>();
            _inputActions.Player.Interact.performed += ctx => m_playerInput.Interaction = ctx.ReadValue<float>();
            _inputActions.Player.Interact.canceled += ctx => m_playerInput.Interaction = ctx.ReadValue<float>();
            _inputActions.Player.Pause.performed += ctx => m_playerInput.Pause = ctx.ReadValue<float>();
            _inputActions.Player.Pause.canceled += ctx => m_playerInput.Pause = ctx.ReadValue<float>();
            
            
            _inputActions.Menus.Navigation.performed += ctx => m_menuInput.Navigation = ctx.ReadValue<Vector2>();
            _inputActions.Menus.Navigation.canceled += ctx => m_menuInput.Navigation = ctx.ReadValue<Vector2>();
            _inputActions.Menus.Confirm.performed += ctx => m_menuInput.Confirm = ctx.ReadValue<float>();
            _inputActions.Menus.Confirm.canceled += ctx => m_menuInput.Confirm = ctx.ReadValue<float>();
            _inputActions.Menus.Back.performed += ctx => m_menuInput.Back = ctx.ReadValue<float>();
            _inputActions.Menus.Back.canceled += ctx => m_menuInput.Back = ctx.ReadValue<float>();
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

    public PlayerInputStruct PlayerInput => m_playerInput;

    public MenuInputStruct MenuInput => m_menuInput;
}
