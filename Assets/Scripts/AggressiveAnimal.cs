using UnityEngine;

public class AggressiveAnimal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.TriggerAnimalHit();
            Destroy(gameObject);
        }
    }
}