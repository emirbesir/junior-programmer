using System.Collections;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    [Header("Powerup")]
    public PowerupType currentPowerupType;
    [SerializeField] private GameObject powerupIndicator;
    [SerializeField] private Material powerupIndicatorMaterial;

    [Header("Pushback")]
    [SerializeField] private float pushbackStrength = 15.0f;

    [Header("Rockets")]
    [SerializeField] private GameObject rocketPrefab;

    private Coroutine powerupCountdownCoroutine;
    private Rigidbody playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        UpdateIndicatorPosition(powerupIndicator);
    }

    private void UpdateIndicatorPosition(GameObject indicator)
    {
        indicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            HandlePowerupPickup(other);
        }
    }

    private void HandlePowerupPickup(Collider powerupCollider)
    {
        currentPowerupType = powerupCollider.gameObject.GetComponent<Powerup>().powerupType;
        Destroy(powerupCollider.gameObject);

        if (powerupCountdownCoroutine != null)
        {
            StopCoroutine(powerupCountdownCoroutine);
            powerupIndicator.SetActive(false);
        }

        SetCurrentPowerupIndicator();
        powerupIndicator.SetActive(true);
        powerupCountdownCoroutine = StartCoroutine(PowerupCountdownRoutine());
    }

    private void SetCurrentPowerupIndicator()
    {
        switch (currentPowerupType)
        {
            case PowerupType.Pushback:
                powerupIndicatorMaterial.color = Color.white;
                break;
            case PowerupType.Rockets:
                powerupIndicatorMaterial.color = Color.red;
                StartCoroutine(LaunchRocketsRoutine());
                break;
            case PowerupType.Smash:
                powerupIndicatorMaterial.color = Color.green;
                StartCoroutine(SmashRoutine());
                break;
            default:
                powerupIndicator = null;
                break;
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(6);
        powerupIndicator.SetActive(false);
        currentPowerupType = PowerupType.None;
    }

    private IEnumerator LaunchRocketsRoutine()
    {
        for (int i = 0; i < 3; i++)
        {
            LaunchRockets();
            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator SmashRoutine()
    {
        while (currentPowerupType == PowerupType.Smash)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.linearVelocity = new Vector3(0, 15, 0);
                yield return new WaitForSeconds(0.2f);
                playerRb.linearVelocity = new Vector3(0, -50, 0);
                yield return new WaitForSeconds(0.1f);
                playerRb.linearVelocity = new Vector3(0, 0, 0);
                foreach (Enemy enemy in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < 6)
                    {
                        Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                        Vector3 awayFromPlayer = enemy.transform.position - transform.position;
                        enemyRigidbody.AddForce(awayFromPlayer * pushbackStrength, ForceMode.Impulse);
                    }
                }
            }
            yield return null;
        }
    }

    public void PushbackEnemy(Collision collision)
    {
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
        enemyRigidbody.AddForce(awayFromPlayer * pushbackStrength, ForceMode.Impulse);
    }

    private void LaunchRockets()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy enemy in enemies)
        {
            GameObject tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
            tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
        }
    }
}
