using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private int _enemyCount;
    [SerializeField] private int _waveNumber = 1;
    [SerializeField] private GameObject[] _powerupPrefabs;

    [SerializeField] private float _powerupSpawnRange = 12;
    [SerializeField] private float _enemySpawnRange = 23;

    private void Start()
    {
        SpawnEnemyWave(_waveNumber);
        SpawnPowerup(1);
    }

    private void Update()
    {
        _enemyCount = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None).Length;
        if (_enemyCount == 0)
        {
            _waveNumber++;
            SpawnEnemyWave(_waveNumber);
            SpawnPowerup(1);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        int index = Random.Range(0, _enemyPrefabs.Length);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(_enemyPrefabs[index], GenerateEnemySpawnPosition(), Quaternion.identity);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        int index = Random.Range(0, _powerupPrefabs.Length);
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(_powerupPrefabs[index], GeneratePowerupSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateEnemySpawnPosition()
    {
        int spawnPoint = Random.Range(0, 4);
        switch (spawnPoint)
        {
            case 0:
                return new Vector3(Random.Range(-_enemySpawnRange, _enemySpawnRange), 1, _enemySpawnRange);
            case 1:
                return new Vector3(Random.Range(-_enemySpawnRange, _enemySpawnRange), 1, -_enemySpawnRange);
            case 2:
                return new Vector3(_enemySpawnRange, 1, Random.Range(-_enemySpawnRange, _enemySpawnRange));
            case 3:
                return new Vector3(-_enemySpawnRange, 1, Random.Range(-_enemySpawnRange, _enemySpawnRange));
            default:
                Debug.LogError("Invalid spawn point");
                return new Vector3(_enemySpawnRange, 1, _enemySpawnRange);
        }
    }

    private Vector3 GeneratePowerupSpawnPosition()
    {
        return new Vector3(Random.Range(-_powerupSpawnRange, _powerupSpawnRange), 1, Random.Range(-_powerupSpawnRange, _powerupSpawnRange));
    }
}
