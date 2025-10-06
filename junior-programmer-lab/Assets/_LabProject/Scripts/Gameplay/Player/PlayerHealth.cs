using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private FloatReference _startingHealth;
    [SerializeField] private FloatVariable _currentHealth;
    [SerializeField] private bool _resetOnStart = true;
    [SerializeField] private UnityEvent _onDamageEvent;
    [SerializeField] private UnityEvent _onDeathEvent;

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
        _onDamageEvent.Invoke();
        _currentHealth.ApplyChange(-damage);
        if (_currentHealth.Value <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _onDeathEvent.Invoke();
        Destroy(gameObject);
    }
}