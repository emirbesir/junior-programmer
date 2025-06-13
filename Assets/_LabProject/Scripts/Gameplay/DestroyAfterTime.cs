using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [Header("Destroy Settings")]
    [SerializeField] private float destroyTime = 7f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
