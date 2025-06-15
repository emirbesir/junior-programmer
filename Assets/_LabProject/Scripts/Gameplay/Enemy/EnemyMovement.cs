using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    [SerializeField] private FloatVariable _moveSpeed;
    private Transform _moveTarget;

    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _moveTarget = GameObject.FindGameObjectWithTag("Campfire").transform;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        _rb2d.linearVelocity = (_moveTarget.position - transform.position).normalized * _moveSpeed.Value;
    }
}
