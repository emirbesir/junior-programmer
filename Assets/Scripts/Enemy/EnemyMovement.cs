using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private GameObject target;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        if (target)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            rb.linearVelocity = direction * movementSpeed;
        }
    }
}