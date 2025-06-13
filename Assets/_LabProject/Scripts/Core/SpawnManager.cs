using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<EnemyConfig> enemyConfigs;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnDistance = 15f;

    private float _nextSpawnTime;

    private void Start()
    {
        _nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        EnemyConfig selectedConfig = GetRandomEnemyConfig();
        Vector3 spawnPosition = GetRandomSpawnPosition();

        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyComponent = enemyInstance.GetComponent<Enemy>();
        
        enemyComponent.InitializeEnemy(selectedConfig);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float angle = Random.Range(0f, 2 * Mathf.PI);

        float x = Mathf.Cos(angle) * spawnDistance;
        float y = Mathf.Sin(angle) * spawnDistance;

        return new Vector3(x, y, 0f);
    }

    private EnemyConfig GetRandomEnemyConfig()
    {
        int randomIndex = Random.Range(0, enemyConfigs.Count);
        return enemyConfigs[randomIndex];
    }
}
