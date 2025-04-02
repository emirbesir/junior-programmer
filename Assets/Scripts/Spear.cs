using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spear : MonoBehaviour
{
    [Header("Spear Settings")]
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float destroyDelay = 10f;

    private Rigidbody rb;
    private bool isOnGround = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isOnGround && collision.gameObject.CompareTag("Enemy"))
        {
            var health = collision.gameObject.GetComponent<EnemyHealth>();
            if (health) health.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            rb.linearVelocity = Vector3.zero;
            Destroy(gameObject, destroyDelay);
        }
    }
}