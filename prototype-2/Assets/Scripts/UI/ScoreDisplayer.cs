using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [Header("Score UI Elements")]
    [SerializeField] private TMP_Text scoreText;
    [Header("Score Settings")]
    [SerializeField] private int currentScore;
    private int startingScore = 0;
    private void OnEnable()
    {
        EventManager.OnScoreIncrease += IncreaseScore;
    }
    private void OnDisable()
    {
        EventManager.OnScoreIncrease -= IncreaseScore;
    }
    private void Start()
    {
        startingScore = 0;
        currentScore = startingScore;
        UpdateScoreUI();
    }

    public void IncreaseScore()
    {
        currentScore++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore;
    }
}
