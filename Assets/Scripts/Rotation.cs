using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Rotation Speed")]
    [SerializeField] private float rotationSpeed = 90.0f;
    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
