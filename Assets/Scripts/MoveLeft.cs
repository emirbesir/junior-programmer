using UnityEngine;
using UnityEngine.UIElements;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
