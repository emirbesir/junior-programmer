using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform target;
    
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        _rb2d.linearVelocity = (target.position - transform.position).normalized * speed;
    }
}
