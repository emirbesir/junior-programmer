using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private FloatReference _startingHealth;
    [SerializeField] private bool _resetOnStart = true;
    [SerializeField] private UnityEvent _onEnemyDamaged;
    [SerializeField] private UnityEvent _onEnemyDeath;
    
    private float _currentHealth;

    private void Start()
    {
        if (_resetOnStart)
        {
            _currentHealth = _startingHealth.Value;
        }
    }

    public void Heal(float healAmount)
    {
        _currentHealth += healAmount;
        if (_currentHealth > _startingHealth.Value)
        {
            _currentHealth = _startingHealth.Value;
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        _onEnemyDamaged.Invoke();
    }

    private void Die()
    {
        _onEnemyDeath.Invoke();
        Destroy(gameObject);
    }
}
