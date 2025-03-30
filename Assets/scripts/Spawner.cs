using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private PlayerController _target;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private float _spawnRate;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 2, _spawnRate);
    }

    private void Spawn()
    {
        int point = Random.Range(0, _points.Length);
        int enemy = Random.Range(0, _enemies.Length);
        GameObject enemyObject = Instantiate(_enemies[enemy], _points[point].position, Quaternion.identity);
        enemyObject.GetComponent<enemy>().SetTarget(_target);
    }
}