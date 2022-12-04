using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerBehavior : PersonBehavior
{
    public Player Player;
    [SerializeField] private UIInGame _uiInGame;
    [SerializeField] private GameObject _shotPrefab, _menuPause, _menuVictory, _menuDead;
    private float _fixedDeltaTimeInitial;
    private bool _isGamePaused;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int IsShooting = Animator.StringToHash("IsShooting");

    public void OnMovement(Vector2 movementDirection)
    {
        Player.IsMoving = movementDirection.x != 0;
        Player.Animator.SetBool(IsMoving, Player.IsMoving);
        Player.MoveDirection = new Vector2(movementDirection.x, 0);
        if(!Player.IsMoving) return;
        Player.VisionSide = movementDirection;
    }

    public void OnShot(bool isActive)
    {
        StartCoroutine(ShotRoutine());
        Player.IsShooting = isActive;
        Player.AnimatorHand.SetBool(IsShooting, isActive);
    }

    public void OnSlowMotion(bool isActive)
    {
        if(!isActive || Player.SlowMotionEnergy <= 0)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = _fixedDeltaTimeInitial * 1.0f;
            Player.OnSlowMotion = false;
            return;
        }

        Player.OnSlowMotion = true;
        Time.timeScale = 0.5f;
        
        Time.fixedDeltaTime = _fixedDeltaTimeInitial * Time.timeScale;
    }
    
    public void OnChangeGravity(bool isActive)
    {
        if(!isActive) return;

        var gravityScale = -Player.Rigidbody.gravityScale;
        Player.Rigidbody.gravityScale = gravityScale;
    }

    public void OnJump(bool isStarting)
    {
        if(!isStarting) return;
        Player.Rigidbody.AddForce(Player.Rigidbody.gravityScale > 0
            ? new Vector2(0, Player.JumpForce)
            : new Vector2(0, -Player.JumpForce));
    }

    public void OnPause(bool isPausing)
    {
        if(!isPausing) return;
        Cursor.visible = true;
        Time.timeScale = 0;
        _menuPause.SetActive(true);
    }
    

    public override void Hit()
    {
        Player.Hp -= 10;
    }
    
    public override void Die()
    {
        _menuDead.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Destroy(gameObject);
    }

    private IEnumerator ShotRoutine()
    {
        var shotDelay = new WaitForSeconds(0.1f);
        while (Player.IsShooting)
        {
            Instantiate(_shotPrefab, Player.Transform.position, Player.Transform.rotation);
            yield return shotDelay;
        }
    }

    private void PlayerMove()
    {
        if(!Player.IsMoving) return;
        
        Player.Rigidbody.drag = Player.MoveSpeed / (Player.MoveSpeed * 0.2f);
        Player.Rigidbody.AddForce(Player.MoveDirection * Player.MoveSpeed, ForceMode2D.Impulse);
    }

    private void AdjustCameraOnPlayer()
    {
        var positionNew = Player.TransformCamera.position;
        positionNew = new Vector3(Player.Transform.position.x, positionNew.y, positionNew.z);
        Player.TransformCamera.position = positionNew;
    }

    private void SlowMotionDrainEnergy()
    {
        Player.SlowMotionEnergy += Player.OnSlowMotion ? -0.3f : 0;
        Player.SlowMotionEnergy += !Player.OnSlowMotion && Player.SlowMotionEnergy < 100 ? 0.1f : 0;

        if (Player.SlowMotionEnergy > 0) return;
        
        Time.timeScale = 1;
        Time.fixedDeltaTime = _fixedDeltaTimeInitial * 1.0f;
        Player.OnSlowMotion = false;
    }
    private void Awake()
    {
        _fixedDeltaTimeInitial = Time.fixedDeltaTime;
    }
    
    private void Start()
    {
        Cursor.visible = false;
        Player.Transform = transform;
        Player.Rigidbody = GetComponent<Rigidbody2D>();
        Player.Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AdjustCameraOnPlayer();
        Player.AdjustRotation();
    }

    private void LateUpdate()
    {
        _uiInGame.SetHpAndEnergy(Player.Hp, (int)Player.SlowMotionEnergy);
    }

    private void FixedUpdate()
    {
        SlowMotionDrainEnergy();
        PlayerMove();
        
        if (!(Player.Transform.position.y > 5) && !(Player.Transform.position.y < -5)) return;
        Die();
    }
}