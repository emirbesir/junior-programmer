using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyConfig config;
    [SerializeField] private Transform target;

    private EnemyHealth _health;
    private EnemyAttack _attack;
    private EnemyMovement _movement;

    private void Awake()
    {
        _health = gameObject.GetComponent<EnemyHealth>();
        _attack = gameObject.GetComponent<EnemyAttack>();
        _movement = gameObject.GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        _health?.Initialize(config);
        _attack?.Initialize(config);
        _movement?.Initialize(config, target);
    }
}
