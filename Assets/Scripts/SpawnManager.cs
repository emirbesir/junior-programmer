using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] bossPrefabs;
    [Header("Powerup")]
    [SerializeField] private GameObject[] powerupPrefabs;
    [Header("Spawn")]
    [SerializeField] private float spawnRange = 9.0f;
    [Header("Wave")]
    [SerializeField] private int enemyCount;
    [SerializeField] private int waveNumber = 1;

    private void Start()
    {
        SpawnPowerup(1);
        SpawnEnemyWave(waveNumber);
    }

    private void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnPowerup(1);
            SpawnEnemyWave(waveNumber);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        if (enemiesToSpawn % 5 == 0)
        {
            SpawnBossWave(1);
            SpawnEnemyWave((int) Mathf.Ceil(enemiesToSpawn / 5.0f) % 10);
        }
        else
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[enemyIndex], GenerateSpawnPosition(), enemyPrefabs[enemyIndex].transform.rotation);
            }
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            int powerupIndex = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[powerupIndex], GenerateSpawnPosition(), powerupPrefabs[powerupIndex].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpawnBossWave(int bossesToSpawn)
    {
        for (int i = 0; i < bossesToSpawn; i++)
        {
            int bossIndex = Random.Range(0, bossPrefabs.Length);
            Instantiate(bossPrefabs[bossIndex], GenerateSpawnPosition(), bossPrefabs[bossIndex].transform.rotation);
        }
    }
}
