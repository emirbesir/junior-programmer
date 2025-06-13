using UnityEngine;

public class Spear : MonoBehaviour
{
    [Header("Spear Settings")]
    [SerializeField] private float speed = 10f;
    
    private float _damage;
    private Vector3 _moveDirection;

    public void InitializeSpear(float damage, Vector3 moveDirNormalized)
    {
        _damage = damage;
        _moveDirection = moveDirNormalized;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * _moveDirection, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
