using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyConfig _config;
    private float _nextAttackTime;

    public void Initialize(EnemyConfig config)
    {
        _config = config;
        _nextAttackTime = Time.time + _config.TimeBetweenAttacks;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Time.time >= _nextAttackTime && other.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            Attack(damageable);
        }
    }

    private void Attack(IDamageable damageable)
    {
        damageable.TakeDamage(_config.AttackDamage);
        _nextAttackTime = Time.time + _config.TimeBetweenAttacks;
    }
}
