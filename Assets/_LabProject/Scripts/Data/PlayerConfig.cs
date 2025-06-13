using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/Characters/PlayerConfig", order = 0)]
public class PlayerConfig : ScriptableObject
{
    [Header("Health Settings")]
    public float MaxHealth = 100f;

    [Header("Attack Settings")]
    public float AttackDamage = 20f;
    public float TimeBetweenAttacks = 0.5f;

    [Header("Movement Settings")]
    public float Speed = 7f;

}
