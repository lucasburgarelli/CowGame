using System;
using UnityEngine;
public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    private float _movementCount;
    private void Start()
    {
        _platform.Transform = transform;
        _platform.StartingPosition = _platform.Transform.position;
    }

    private void FixedUpdate()
    {
        var actualPosition = new Vector2
        {
            x = Mathf.Sin(_movementCount) * _platform.RotationMultipliers.x,
            y = Mathf.Cos(_movementCount) * _platform.RotationMultipliers.y
        };
        _platform.Transform.position = _platform.StartingPosition + actualPosition;
        _movementCount += 0.05f * _platform.Speed;
        
        if (_movementCount < 6.28) return;
        
        _movementCount = 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player")) return;
        collision.gameObject.transform.SetParent(_platform.Transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
