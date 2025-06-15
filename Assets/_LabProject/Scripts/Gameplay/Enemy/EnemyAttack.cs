using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private FloatVariable _attackDamage;
    [SerializeField] private FloatVariable _timeBetweenAttacks;
    private float _nextAttackTime;

    private void Start()
    {
        _nextAttackTime = Time.time + _timeBetweenAttacks.Value;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Time.time >= _nextAttackTime && other.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_attackDamage.Value);
            _nextAttackTime = Time.time + _timeBetweenAttacks.Value;
        }
    }
}
