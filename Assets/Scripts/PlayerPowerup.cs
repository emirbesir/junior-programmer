using System.Collections;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    [Header("Powerup")]
    public PowerupType currentPowerupType;

    [Header("Pushback")]
    [SerializeField] private GameObject pushbackIndicator;
    [SerializeField] private float pushbackStrength = 15.0f;

    [Header("Rockets")]
    [SerializeField] private GameObject rocketIndicator;
    [SerializeField] private GameObject rocketPrefab;

    private GameObject currentPowerupIndicator;
    private Coroutine powerupCountdownCoroutine;

    private void Update()
    {
        UpdateIndicatorPosition(pushbackIndicator);
        UpdateIndicatorPosition(rocketIndicator);
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
            currentPowerupIndicator.SetActive(false);
        }

        SetCurrentPowerupIndicator();
        currentPowerupIndicator.SetActive(true);
        powerupCountdownCoroutine = StartCoroutine(PowerupCountdownRoutine());
    }

    private void SetCurrentPowerupIndicator()
    {
        switch (currentPowerupType)
        {
            case PowerupType.Pushback:
                currentPowerupIndicator = pushbackIndicator;
                break;
            case PowerupType.Rockets:
                currentPowerupIndicator = rocketIndicator;
                StartCoroutine(LaunchRocketsRoutine());
                break;
            default:
                currentPowerupIndicator = null;
                break;
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(6);
        currentPowerupIndicator.SetActive(false);
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
