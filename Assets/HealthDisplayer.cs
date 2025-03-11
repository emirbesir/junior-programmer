using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : MonoBehaviour
{

    // Array of sprites representing different health states
    [Header("Health Sprites")]
    [SerializeField] private Sprite[] healthSprites;

    // Array of Image components to display health
    [Header("Health UI Elements")]
    [SerializeField] private Image[] healthRend;

    // Current, Initial, Maximum health of the player
    [Header("Health Settings")]
    [SerializeField] private int currentHealth;
    private int startingHealth;
    private int maxHealth;

    // Panel to display when the game is over
    [Header("Game Over Settings")]
    [SerializeField] private GameObject restartPanel;

    // Subscribe to events when the object is enabled
    void OnEnable()
    {
        EventManager.OnOutOfBounds += TakeDamage;
        EventManager.OnAnimalHit += TakeDamage;
    }

    // Unsubscribe from events when the object is disabled
    void OnDisable()
    {
        EventManager.OnOutOfBounds -= TakeDamage;
        EventManager.OnAnimalHit -= TakeDamage;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = healthRend.Length;
        startingHealth = maxHealth;
        currentHealth = startingHealth;
        RefreshHealthUI();
    }

    // Method to handle taking damage
    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            if (currentHealth == 0)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
                restartPanel.SetActive(true);
            }
            RefreshHealthUI();
        }
    }

    // Method to update the health UI
    void RefreshHealthUI()
    {
        for (int i = 0; i < healthRend.Length; i++)
        {
            if (i < currentHealth)
            {
                healthRend[i].sprite = healthSprites[1];
            }
            else
            {
                healthRend[i].sprite = healthSprites[0];
            }
        }
    }
}

