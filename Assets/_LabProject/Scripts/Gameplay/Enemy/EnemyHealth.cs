using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private EnemyConfig _config;
    private float _currentHealth;
    
    public void Initialize(EnemyConfig config)
    {
        _config = config;
        _currentHealth = _config.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
