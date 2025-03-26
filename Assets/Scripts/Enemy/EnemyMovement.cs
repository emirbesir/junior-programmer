using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Movement")]
    [SerializeField] private float movementSpeed = 10.0f;
    [Header("Enemy Target")]
    [SerializeField] private GameObject target;
    private Rigidbody enemyRb;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        enemyRb.linearVelocity = direction * movementSpeed;
    }
}
