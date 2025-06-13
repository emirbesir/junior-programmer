using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    private EnemyConfig _config;
    private Transform _target;
    private Rigidbody2D _rb2d;

    public void Initialize(EnemyConfig config)
    {
        _config = config;
        _target = GameObject.FindGameObjectWithTag("Campfire").transform;
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        _rb2d.linearVelocity = (_target.position - transform.position).normalized * _config.Speed;
    }
}
