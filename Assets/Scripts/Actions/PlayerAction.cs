using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerAction : BaseAction
{
    protected InputAction.CallbackContext _context;
    protected PlayerBehavior _behavior;

    protected PlayerAction(InputAction.CallbackContext context, PlayerBehavior behavior)
    {
        _context = context;
        _behavior = behavior;
    }
}
