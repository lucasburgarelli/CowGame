using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotAction : PlayerAction
{
    public ShotAction(InputAction.CallbackContext context, PlayerBehavior behavior) : base(context, behavior)
    {
    }

    public override void Execute()
    {
        _behavior.OnShot(_context.phase != InputActionPhase.Canceled);
    }
}
