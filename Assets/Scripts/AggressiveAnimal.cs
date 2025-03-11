using UnityEngine;

public class AggressiveAnimal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the aggressive animal's trigger zone!");
            Debug.Log("Game Over!");
        }
    }
}
