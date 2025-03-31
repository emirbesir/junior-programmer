using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;
    public bool isGameActive = true;

    [Header("UI Settings")]
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(score);
        isGameActive = true;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
