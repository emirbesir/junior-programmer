using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnOutOfBounds;
    public static event Action OnAnimalHit;

    public static void TriggerOutOfBounds()
    {
        OnOutOfBounds?.Invoke();
    }
    public static void TriggerAnimalHit()
    {
        OnAnimalHit?.Invoke();
    }
}
