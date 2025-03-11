using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    [SerializeField] private float timeBetweenSpawns = 1.0f;
    private float nextSpawnTime;
    private void Start()
    {
        nextSpawnTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
