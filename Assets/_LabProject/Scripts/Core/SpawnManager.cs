using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<EnemyConfig> enemyConfigs;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 2f;

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
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        Vector3 spawnPosition = new Vector3(x, y, 0f);

        return spawnPosition;
    }
    
    private EnemyConfig GetRandomEnemyConfig()
    {
        if (enemyConfigs.Count == 0)
        {
            Debug.LogWarning("No enemy configs available.");
            return null;
        }

        int randomIndex = Random.Range(0, enemyConfigs.Count);
        return enemyConfigs[randomIndex];
    }
}
