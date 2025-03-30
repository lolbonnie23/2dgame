using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed = 1;
    [SerializeField] private Transform _gun;
    [SerializeField] private float _health;
    [SerializeField] private Slider _slider;
    private Camera _camera;
    private Vector2 _move;
    private Animator _animator;
    

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
        _slider.maxValue = _health;
        _slider.value = _health;
    }

    void FixedUpdate()
    {
        _move.x = Input.GetAxisRaw("Horizontal");
        _move.y = Input.GetAxisRaw("Vertical");
        _rb.velocity = _move * _speed;

        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x)
        {
            transform.localEulerAngles = Vector3.up * 180;
            _gun.localScale = new Vector3(1, -1, 1);
        }
        else if (mousePos.x > transform.position.x)
        {
            transform.localEulerAngles = Vector3.zero;
            _gun.localScale = Vector3.one;
        }

        if (_move.x == 0 && _move.y == 0)
            _animator.SetBool("run", false);
        else
            _animator.SetBool("run", true);
    }


    public void Takedamage(float damage)
    {
        _slider.value -= damage;

        if (_slider.value <= 0)
        {
            _rb.bodyType = RigidbodyType2D.Static;
            enabled = false;
            _gun.gameObject.SetActive(false);
            UIManager.playerAction.Invoke();
            enabled = false;
        }
    }

    


}
