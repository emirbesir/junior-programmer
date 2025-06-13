using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyConfig config;

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

    public void InitializeEnemy() => InitializeEnemy(config);

    public void InitializeEnemy(EnemyConfig customConfig)
    {
        _health?.Initialize(customConfig);
        _attack?.Initialize(customConfig);
        _movement?.Initialize(customConfig);
    }
}
