using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Manager Prefab Settings")]
    [SerializeField] private GameObject[] animalPrefabs;
    [Header("Spawn Manager Position Settings")]
    [SerializeField] private float spawnRangeX = 15f;
    [SerializeField] private float spawnPosZ = 20f;
    [Header("Spawn Manager Timing Settings")]
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;

    [Header("Aggressive Spawn Manager Position Settings")]
    [SerializeField] private float aggroSpawnPosX = 20f;
    [SerializeField] private float aggroSpawnRangeZ = 15f;
    [Header("Aggressive Spawn Manager Timing Settings")]
    [SerializeField] private float aggroStartDelay = 3f;
    [SerializeField] private float aggroSpawnInterval = 3f;
    private string spawnMethodName = "SpawnRandomAnimal";
    private string aggroSpawnMethodName = "SpawnAggressiveAnimal";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(spawnMethodName, startDelay, spawnInterval);
        InvokeRepeating(aggroSpawnMethodName, aggroStartDelay, aggroSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnRandomAnimal()
    {
        int spawnIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[spawnIndex], spawnPos, animalPrefabs[spawnIndex].transform.rotation);
    }

    private void SpawnAggressiveAnimal()
    {
        int spawnIndex = Random.Range(0, animalPrefabs.Length);
        int leftOrRight = Random.Range(0, 2);
        Quaternion quaternion = new Quaternion();
        if (leftOrRight == 0)
        {
            Vector3 rotation = new Vector3(0, 90, 0);
            quaternion.eulerAngles = rotation;
            Vector3 spawnPos = new Vector3(-aggroSpawnPosX, 0, Random.Range(0, aggroSpawnRangeZ));
            Instantiate(animalPrefabs[spawnIndex], spawnPos, quaternion);
        }
        else
        {
            Vector3 rotation = new Vector3(0, -90, 0);
            quaternion.eulerAngles = rotation;
            Vector3 spawnPos = new Vector3(aggroSpawnPosX, 0, Random.Range(0, aggroSpawnRangeZ));
            Instantiate(animalPrefabs[spawnIndex], spawnPos, quaternion);
        }


    }
}
