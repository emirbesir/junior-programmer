using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SimpleSlider : MonoBehaviour
{
    [Header("Slider Settings")]
    [SerializeField] private FloatReference _maxValue;
    [SerializeField] private FloatVariable _currentValue;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.value = _currentValue.Value / _maxValue.Value;
    }
}
