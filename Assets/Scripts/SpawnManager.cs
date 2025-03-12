using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Vector3 spawnPos = new Vector3(25, 0, 0);
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float repeatRate = 2f;
    private string spawnObstacleMethod = "SpawnObstacle";

    void Start()
    {
        InvokeRepeating(spawnObstacleMethod, startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
