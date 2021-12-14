using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WendyInputController : MonoBehaviour
{
    private WendyInputs wendyInputs;
    private CharacterController wendyController;

    private void Awake()
    {
        wendyInputs = new WendyInputs();

        wendyController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        wendyInputs.CharacterControls.JumpPress.Enable();
        wendyInputs.CharacterControls.JumpPress.performed += JumpPressed;
        
        wendyInputs.CharacterControls.JumpRelease.Enable();
        wendyInputs.CharacterControls.JumpRelease.performed += JumpReleased;
        
        wendyInputs.CharacterControls.TonguePress.Enable();
        wendyInputs.CharacterControls.TonguePress.performed += TonguePressed;
        
        wendyInputs.CharacterControls.TongueRelease.Enable();
        wendyInputs.CharacterControls.TongueRelease.performed += TongueReleased;
        
        wendyInputs.CharacterControls.Position.Enable();
        wendyInputs.CharacterControls.Position.performed += PositionUpdated;
        
        wendyInputs.CharacterControls.Direction.Enable();
        wendyInputs.CharacterControls.Direction.performed += DirectionUpdated;
    }
    
    private void OnDisable()
    {
        wendyInputs.CharacterControls.JumpPress.Disable();
        wendyInputs.CharacterControls.JumpPress.performed -= JumpPressed;
        
        wendyInputs.CharacterControls.JumpRelease.Disable();
        wendyInputs.CharacterControls.JumpRelease.performed -= JumpReleased;
        
        wendyInputs.CharacterControls.TonguePress.Disable();
        wendyInputs.CharacterControls.TonguePress.performed -= TonguePressed;
        
        wendyInputs.CharacterControls.TongueRelease.Disable();
        wendyInputs.CharacterControls.TongueRelease.performed -= TongueReleased;
        
        wendyInputs.CharacterControls.Position.Disable();
        wendyInputs.CharacterControls.Position.performed -= PositionUpdated;
        
        wendyInputs.CharacterControls.Direction.Disable();
        wendyInputs.CharacterControls.Direction.performed -= DirectionUpdated;
    }

    private void JumpPressed(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            wendyController.SetJumpState(true);
        }
    }

    private void JumpReleased(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            wendyController.SetJumpState(false);
        }
    }
    
    private void TonguePressed(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            wendyController.SetTongueState(true);
        }
    }

    private void TongueReleased(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            wendyController.SetTongueState(false);
        }
    }
    
    private void PositionUpdated(InputAction.CallbackContext ctx)
    {
        Vector2 inputPosition = ctx.ReadValue<Vector2>();
        wendyController.SetCursorPosition(inputPosition.normalized);
    }
    
    private void DirectionUpdated(InputAction.CallbackContext ctx)
    {
        Vector2 inputDirection = ctx.ReadValue<Vector2>();
        wendyController.SetInputDirection(inputDirection.normalized);
    }
}
