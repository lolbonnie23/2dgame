using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerController _target;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;    
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _animator;
    private bool _canAttack;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator.SetBool("run", true);
        _canAttack = true;
    }

    public void SetTarget(PlayerController target)
    {
        _target = target;
    }


    void FixedUpdate()
    {
        if (_target.enabled)
        {
            _rb.velocity = (_target.transform.position - transform.position).normalized * _speed;
            if (_target.transform.position.x > transform.position.x)
            {
                _sr.flipX = false;
            }

            if (_target.transform.position.x < transform.position.x)
            {
                _sr.flipX = true;
            }


            if (Vector2.Distance(_target.transform.position, transform.position) < 2 && _canAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        _canAttack = false;
        int index = Random.Range(1, 3);
        _animator.Play($"attack{index}");
        yield return new WaitForSeconds(0.7f);
        _target.GetComponent<PlayerController>().Takedamage(_damage);
        yield return new WaitForSeconds(0.8f);
        _canAttack = true;
    }

    public void TakeDamage(float damage)
    {
        _health -= _damage;

        if (_health <= 0)
        {
            _animator.Play("death");
            GetComponent<Collider2D>().enabled = false;
            _rb.bodyType = RigidbodyType2D.Static;
            enabled = false;
            Destroy(gameObject, 3);
            UIManager.enemyAction.Invoke();
        }
         
    }
}
