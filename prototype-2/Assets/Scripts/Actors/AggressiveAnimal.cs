using UnityEngine;

public class AggressiveAnimal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.TriggerAnimalHitPlayer();
            Destroy(gameObject);
        }
    }
}