using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private GameObject spearPrefab;
    [SerializeField] private Transform attackPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Instantiate(spearPrefab, attackPoint.position, attackPoint.rotation);
    }
}
