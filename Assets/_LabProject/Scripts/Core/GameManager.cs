using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private FloatReference _levelTimeLimit;
    [SerializeField] private FloatVariable _timeElapsed;
    [SerializeField] private UnityEvent _onGameWinEvent;

    private void Start()
    {
        _timeElapsed.SetValue(0f);
    }

    private void Update()
    {
        _timeElapsed.SetValue(_timeElapsed.Value + Time.deltaTime);

        if (_timeElapsed.Value >= _levelTimeLimit.Value)
        {
            _onGameWinEvent.Invoke();
        }
    }
}
