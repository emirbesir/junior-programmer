using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;

    [Header("UI Settings")]
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            UpdateScore(5);
        }
    }

    private void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + scoreToAdd;
    }
}
