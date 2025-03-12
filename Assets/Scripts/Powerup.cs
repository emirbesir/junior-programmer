using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType
    {
        Strength,
        Rockets,
    }

    [SerializeField] public PowerupType powerupType;
}
