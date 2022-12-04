using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlowMotionAction : PlayerAction
{
    public SlowMotionAction(InputAction.CallbackContext context, PlayerBehavior behavior) : base(context, behavior)
    {
    }

    public override void Execute()
    {
        _behavior.OnSlowMotion(_context.phase != InputActionPhase.Canceled);
    }
}
