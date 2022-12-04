using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeGravityAction : PlayerAction
{
    public ChangeGravityAction(InputAction.CallbackContext context, PlayerBehavior behavior) : base(context, behavior)
    {
    }

    public override void Execute()
    {
        _behavior.OnChangeGravity(_context.phase == InputActionPhase.Started);
    }
}
