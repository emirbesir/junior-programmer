using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/Characters/EnemyConfig", order = 1)]
public class EnemyConfig : ScriptableObject
{
    [Header("Health Settings")]
    public float MaxHealth = 100f;

    [Header("Attack Settings")]
    public float AttackDamage = 10f;
    public float TimeBetweenAttacks = 1f;

    [Header("Movement Settings")]
    public float Speed = 2f;

}
