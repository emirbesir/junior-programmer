using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private PlayerConfig _config;
    private float _currentHealth;

    public void Initialize(PlayerConfig config)
    {
        _config = config;
        _currentHealth = _config.MaxHealth;
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _config.MaxHealth)
        {
            _currentHealth = _config.MaxHealth;
        }
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