using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBehavior : PersonBehavior
{
    public Enemy Enemy;
    public override void Hit()
    {
        Enemy.Hp -= 50;
        if(Enemy.Hp < 0) Die();
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Enemy.VisionSide = -Enemy.VisionSide;
        Enemy.MoveDirection = -Enemy.MoveDirection;
        Enemy.AdjustRotation();
        
        var isNotPlayer = !col.collider.CompareTag("Player");
        if (isNotPlayer) return;
        
        const float heightOffset = 0.6f;
        
        var isPlayerAboveEnemy = Enemy.IsGravityInverted
            ? col.collider.gameObject.transform.position.y < Enemy.Transform.position.y - heightOffset
            : col.collider.gameObject.transform.position.y > Enemy.Transform.position.y + heightOffset;
        
        if (isPlayerAboveEnemy)
        {
            Die();
            return;
        }
        
        col.gameObject.GetComponent<PlayerBehavior>().Die();
    }

    private void Start()
    {
        Enemy.Transform = transform;
        Enemy.Rigidbody = GetComponent<Rigidbody2D>();
        Enemy.Animator = GetComponent<Animator>();
        Enemy.VisionSide = Vector2.right;
        Enemy.MoveDirection = Vector2.right;
        
        if(!Enemy.IsGravityInverted) return;
        
        var gravityScale = -Enemy.Rigidbody.gravityScale;
        Enemy.Rigidbody.gravityScale = gravityScale;
    }
    private void FixedUpdate()
    {
        Enemy.Rigidbody.drag = Enemy.MoveSpeed / (Enemy.MoveSpeed * 0.2f);
        Enemy.Rigidbody.AddForce(Enemy.MoveDirection * Enemy.MoveSpeed, ForceMode2D.Impulse);
    }
}