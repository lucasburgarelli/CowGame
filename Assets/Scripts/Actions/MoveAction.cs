using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAction : PlayerAction
{
    public MoveAction(InputAction.CallbackContext context, PlayerBehavior behavior) : base(context, behavior)
    {
    }

    public override void Execute()
    {
        _behavior.OnMovement(_context.ReadValue<Vector2>());
    }
}
