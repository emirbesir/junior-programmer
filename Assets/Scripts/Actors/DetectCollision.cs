using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            GetComponent<AnimalHunger>().FeedAnimal();
            Destroy(other.gameObject);
        }
    }
}
