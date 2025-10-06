using Unity.VisualScripting;
using UnityEngine;

public class EnemySpeedManager : MonoBehaviour
{
    [Header("Enemy Speed References")]
    [SerializeField] private FloatReference _baseEnemySpeed;
    [SerializeField] private bool _resetOnStart = true;
    [SerializeField] private FloatVariable _enemyMoveSpeed;

    [Header("Time References")]
    [SerializeField] private FloatVariable _timeElapsed;

    [Header("Speed Increase Settings")]
    [SerializeField] private FloatReference _growthFactor;

    private void Start()
    {
        if (_resetOnStart)
        {
            _enemyMoveSpeed.SetValue(_baseEnemySpeed.Value);
        }
    }

    private void Update()
    {
        UpdateEnemyMoveSpeed();
    }

    public void UpdateEnemyMoveSpeed()
    {
        float newSpeed = _baseEnemySpeed.Value * Mathf.Pow(_growthFactor.Value, _timeElapsed.Value);
        _enemyMoveSpeed.SetValue(newSpeed);
    }
}