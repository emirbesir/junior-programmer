using TMPro;
using UnityEngine;

public class GameTimeDisplay : MonoBehaviour
{
    private const float HOURS_IN_DAY = 24f;

    [Header("Game Time Settings")]
    [SerializeField] private FloatReference _timeLimit;
    [SerializeField] private FloatVariable _timeElapsed;

    [Header("Arbitrary Start/End Hours")]
    [SerializeField] private FloatReference _gameStartHour;
    [SerializeField] private FloatReference _gameEndHour;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = GetFormattedTime();
    }

    private string GetFormattedTime()
    {   
        float time = GetTime();
        int hours = Mathf.FloorToInt(time);
        return $"{hours}:00";
    }

    private float GetTime()
    {
        float hours = Mathf.Abs(_gameEndHour.Value - _gameStartHour.Value);
        float hoursElapsed = _timeElapsed.Value * hours / _timeLimit.Value;
        float currentTime = (_gameStartHour.Value + hoursElapsed) % HOURS_IN_DAY;
        return currentTime;
    }
}
