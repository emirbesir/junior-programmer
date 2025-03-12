using UnityEngine;
using UnityEngine.UIElements;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float leftBound = -15f;
    private PlayerController playerControllerScript;
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
