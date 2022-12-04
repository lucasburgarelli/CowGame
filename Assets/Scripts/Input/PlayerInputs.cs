using System;
using System.Collections;
using System.Collections.Generic;
using Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private PlayerBehavior _playerBehavior;
    public void OnMovement(InputAction.CallbackContext context)
    {
        PlayerAction action = new MoveAction(context, _playerBehavior);
        action.Execute();
    }

    public void OnShot(InputAction.CallbackContext context)
    {
        PlayerAction action = new ShotAction(context, _playerBehavior);
        action.Execute();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        PlayerAction action = new JumpAction(context, _playerBehavior);
        action.Execute();
    }

    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        PlayerAction action = new ChangeGravityAction(context, _playerBehavior);
        action.Execute();
    }

    public void OnSlowMode(InputAction.CallbackContext context)
    {
        PlayerAction action = new SlowMotionAction(context, _playerBehavior);
        action.Execute();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        PlayerAction action = new PauseAction(context, _playerBehavior);
        action.Execute();
    }


    private void Start()
    {
        _playerBehavior = GetComponent<PlayerBehavior>();
    }
}
