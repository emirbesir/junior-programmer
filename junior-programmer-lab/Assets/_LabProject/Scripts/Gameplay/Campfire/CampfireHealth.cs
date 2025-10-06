using UnityEngine;
using UnityEngine.Events;

public class CampfireHealth : MonoBehaviour, IDamageable
{
    [Header("Health Settings")]
    [SerializeField] private FloatReference _startingHealth;
    [SerializeField] private bool _resetOnStart = true;
    [SerializeField] private FloatVariable _currentHealth;
    [Header("Events")]
    [SerializeField] private UnityEvent _onDamageEvent;
    [SerializeField] private UnityEvent _onDeathEvent;

    private void Start()
    {
        if (_resetOnStart)
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
            DestroyCampfire();
        }
    }

    private void DestroyCampfire()
    {
        _onDeathEvent.Invoke();
        Destroy(gameObject);
    }
}
