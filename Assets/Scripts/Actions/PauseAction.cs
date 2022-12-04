using UnityEngine.InputSystem;

namespace Actions
{
    public class PauseAction : PlayerAction
    {
        public PauseAction(InputAction.CallbackContext context, PlayerBehavior behavior) : base(context, behavior)
        {
        }
        public override void Execute()
        {
            _behavior.OnPause(_context.phase == InputActionPhase.Started);
        }

    }
}