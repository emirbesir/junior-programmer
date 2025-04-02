using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float enemySpawnRange = 23f;

    [Header("Powerup Settings")]
    [SerializeField] private GameObject[] powerupPrefabs;
    [SerializeField] private float powerupSpawnRange = 12f;

    private int waveNumber = 1;

    private void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);
    }

    private void Update()
    {
        int remainingEnemies = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None).Length;
        if (remainingEnemies == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
        }
    }

    private void SpawnEnemyWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[index], GenerateEnemySpawnPosition(), Quaternion.identity);
        }
    }

    private void SpawnPowerup(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[index], GeneratePowerupSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateEnemySpawnPosition()
    {
        int edge = Random.Range(0, 4);
        float x = Random.Range(-enemySpawnRange, enemySpawnRange);
        float z = Random.Range(-enemySpawnRange, enemySpawnRange);

        switch (edge)
        {
            case 0: return new Vector3(x, 1, enemySpawnRange);
            case 1: return new Vector3(x, 1, -enemySpawnRange);
            case 2: return new Vector3(enemySpawnRange, 1, z);
            case 3: return new Vector3(-enemySpawnRange, 1, z);
            default: return Vector3.zero;
        }
    }

    private Vector3 GeneratePowerupSpawnPosition()
    {
        float x = Random.Range(-powerupSpawnRange, powerupSpawnRange);
        float z = Random.Range(-powerupSpawnRange, powerupSpawnRange);
        return new Vector3(x, 1, z);
    }
}
