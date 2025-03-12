using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform target;
    [Header("Rocket")]
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float powerupStrength = 15.0f;

    private Rigidbody rocketRb;

    private void Awake()
    {
        rocketRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rocketRb.AddForce(direction * Time.deltaTime * speed);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromRocket = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromRocket * powerupStrength, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
