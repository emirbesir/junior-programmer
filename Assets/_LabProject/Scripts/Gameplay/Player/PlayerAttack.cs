using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private FloatVariable _attackDamage;
    [SerializeField] private FloatVariable _timeBetweenAttacks;
    [SerializeField] private GameObject _projectilePrefab;

    private float _nextAttackTime;

    private void Start()
    {
        _nextAttackTime = Time.time + _timeBetweenAttacks.Value;

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextAttackTime)
        {
            PerformAttack();
            _nextAttackTime = Time.time + _timeBetweenAttacks.Value;
        }
    }

    private void PerformAttack()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3 lookDirNormalized = (mouseWorldPosition - transform.position).normalized;
        
        float angle = Mathf.Atan2(lookDirNormalized.y, lookDirNormalized.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        GameObject newProjectile = Instantiate(_projectilePrefab, transform.position, rotation);
        newProjectile.GetComponent<Spear>().InitializeSpear(_attackDamage.Value, lookDirNormalized);
    }
}
