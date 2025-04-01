using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;
    public bool isGameActive = true;

    [Header("Score Settings")]
    [SerializeField] private int score = 0;
    [SerializeField] private GameObject scoreDisplay;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Lives Settings")]
    [SerializeField] private int lives = 3;
    [SerializeField] private GameObject livesDisplay;
    [SerializeField] private TextMeshProUGUI livesText;

    [Header("Title Screen Settings")]
    [SerializeField] private GameObject titleScreen;

    [Header("Pause Screen Settings")]
    [SerializeField] private GameObject pauseScreen;
    public bool isPaused = false;

    [Header("Game Over Settings")]
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject restartButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
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

    public void UpdateLives(int livesToAdd)
    {
        if (isGameActive)
        {
            lives += livesToAdd;
            livesText.text = "Lives: " + lives;
            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        lives = 3;
        UpdateLives(0);
        titleScreen.SetActive(false);
        scoreDisplay.SetActive(true);
        livesDisplay.SetActive(true);
    }

    private void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }
}
