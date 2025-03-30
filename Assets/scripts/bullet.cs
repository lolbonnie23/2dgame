    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2);
    }

    void FixedUpdate()
    {
        _rb.velocity = transform.right * _speed * Time.fixedDeltaTime;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
