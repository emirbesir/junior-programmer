using UnityEngine;
using UnityEngine.UI;

public class VolumeAdjuster : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = audioSource.volume;
    }

    public void AdjustVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}
