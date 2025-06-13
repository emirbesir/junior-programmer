using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    [SerializeField] private GameObject projectilePrefab;

    private PlayerHealth _health;
    private PlayerAttack _attack;
    private PlayerMovement _movement;

    private void Awake()
    {
        _health = gameObject.GetComponent<PlayerHealth>();
        _attack = gameObject.GetComponent<PlayerAttack>();
        _movement = gameObject.GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        _health?.Initialize(config);
        _attack?.Initialize(config, projectilePrefab);
        _movement?.Initialize(config);
    }
}
