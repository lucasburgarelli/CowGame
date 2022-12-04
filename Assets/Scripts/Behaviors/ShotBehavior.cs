using System;
using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    private Shot _shot;
    [SerializeField] private GameObject _personHitPrefab, _wallHitPrefab;

    private void Hit(GameObject hit)
    {
        var isPerson = hit.CompareTag("Player") || hit.CompareTag("Enemy");
        
        if(isPerson) hit.GetComponent<PersonBehavior>().Hit();

        var hitPrefab = isPerson ? _personHitPrefab : _wallHitPrefab;
        
        Instantiate(hitPrefab, _shot.Transform.position, _shot.Transform.rotation);
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Hit(col.gameObject);
    }
    
    private void Awake()
    {
        _shot = new Shot
        {
            Transform = transform,
            Rigidbody = GetComponent<Rigidbody2D>()
        };
        
        var hit = Physics2D.OverlapCircle(_shot.Transform.position, 0.05f);
        
        if (!(_shot.Transform.position.y > 5) && !(_shot.Transform.position.y < -5) || hit == null) return;
        
        Hit(hit.gameObject);
    }

    private void Start()
    {
        _shot.Rigidbody.velocity = _shot.Transform.TransformDirection(new Vector2(_shot.ShotForce, 0));
    }
}
