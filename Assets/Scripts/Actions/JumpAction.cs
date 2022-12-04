using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpAction : PlayerAction
{
    public JumpAction(InputAction.CallbackContext context, PlayerBehavior behavior) : base(context, behavior)
    {
    }

    public override void Execute()
    {
        _behavior.OnJump(_context.phase == InputActionPhase.Started);
    }
}
