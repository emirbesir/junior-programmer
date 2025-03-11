using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float topBound = 30;
    [SerializeField] private float lowerBound = -5;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            EventManager.TriggerOutOfBounds();
            Destroy(gameObject);
        }
    }
}