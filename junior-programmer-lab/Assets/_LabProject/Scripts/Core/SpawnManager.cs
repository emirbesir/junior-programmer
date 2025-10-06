using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject _enemyPrefab;

    [Header("Spawn Settings")]
    [SerializeField] private FloatVariable _spawnInterval;
    [SerializeField] private FloatVariable _spawnDistance;

    private float _nextSpawnTime;

    private void Start()
    {
        _nextSpawnTime = Time.time + _spawnInterval.Value;
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + _spawnInterval.Value;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float angle = Random.Range(0f, 2 * Mathf.PI);

        float x = Mathf.Cos(angle) * _spawnDistance.Value;
        float y = Mathf.Sin(angle) * _spawnDistance.Value;

        return new Vector3(x, y, 0f);
    }
}
