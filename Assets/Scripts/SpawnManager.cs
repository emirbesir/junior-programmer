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
    private string spawnMethodName = "SpawnRandomAnimal";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(spawnMethodName, startDelay, spawnInterval);
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
}
