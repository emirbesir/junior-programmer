using UnityEngine;

public class Spear : MonoBehaviour
{
    [Header("Spear Properties")]
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 10f;
    [SerializeField] private bool isOnGround = false;
    [Header("Destroy Settings")]
    [SerializeField] private float destroyDelay = 10f;

    private Rigidbody rb;
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
        if (collision.gameObject.CompareTag("Enemy") && !isOnGround)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Destroy(gameObject, destroyDelay);
            rb.linearVelocity = Vector3.zero;
        }
    }
}
