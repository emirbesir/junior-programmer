using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnOutOfBounds;
    public static event Action OnAnimalHitPlayer;
    public static event Action OnScoreIncrease;

    public static void TriggerOutOfBounds()
    {
        OnOutOfBounds?.Invoke();
    }
    public static void TriggerAnimalHitPlayer()
    {
        OnAnimalHitPlayer?.Invoke();
    }
    public static void TriggerScoreIncrease()
    {
        OnScoreIncrease?.Invoke();
    }
}
