using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _muzzle;


    private Camera _camera;
    private bool _canShot;
    
    void Start()
    {
        _camera = Camera.main;
        _canShot = true;
    }

    void FixedUpdate()
    {
        Vector3 playerPos = transform.position;
        Vector3 mouse = _camera.ScreenToWorldPoint(Input.mousePosition) - playerPos;
        float rotate = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotate);

        if (Input.GetMouseButton(0) && _canShot)
        {
           StartCoroutine(Shot()); 
        }
    }

    private IEnumerator Shot()
    {
        _canShot = false; 
        Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
        yield return new WaitForSeconds(_fireRate);
        _canShot = true;

    }
}
