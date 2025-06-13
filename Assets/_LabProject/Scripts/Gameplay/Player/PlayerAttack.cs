using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerConfig _config;
    private GameObject _projectilePrefab;
    private float _nextAttackTime;

    public void Initialize(PlayerConfig config, GameObject projectilePrefab)
    {
        _config = config;
        _projectilePrefab = projectilePrefab;
        _nextAttackTime = Time.time + _config.TimeBetweenAttacks;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= _nextAttackTime)
        {
            PerformAttack();
            _nextAttackTime = Time.time + _config.TimeBetweenAttacks;
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
        newProjectile.GetComponent<Spear>().InitializeSpear(_config.AttackDamage, lookDirNormalized);
    }
}
