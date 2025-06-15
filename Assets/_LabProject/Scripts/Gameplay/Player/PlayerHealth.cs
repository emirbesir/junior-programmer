using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private FloatReference _startingHealth;
    [SerializeField] private FloatVariable _currentHealth;
    [SerializeField] private bool _resetOnStart = true;

    private void Start()
    {
        if (_resetOnStart)
        {
            _currentHealth.SetValue(_startingHealth.Value);
        }
    }

    public void Heal(float healAmount)
    {
        _currentHealth.ApplyChange(healAmount);
        if (_currentHealth.Value > _startingHealth.Value)
        {
            _currentHealth.SetValue(_startingHealth.Value);
        }
    }
    
    public void TakeDamage(float damage)
    {
        _currentHealth.ApplyChange(-damage);
        if (_currentHealth.Value <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}