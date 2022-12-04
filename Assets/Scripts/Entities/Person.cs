using System;
using UnityEngine;

[Serializable]
public class Person : Entity
{
    public Animator AnimatorHand;
    public int Hp = 100;
    public float MoveSpeed = 500;
    [HideInInspector] public Vector2 MoveDirection, VisionSide;
    
    public void AdjustRotation()
    {
        var isAimToRight = VisionSide.x > 0;
        var isGravityActive = Rigidbody.gravityScale > 0;
        var rotation = new Vector2(isGravityActive ? 0 : 180, isAimToRight ? 0 : 180);

        Transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
    }
}
