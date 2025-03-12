using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10.0f;
    private float xBounds = 25f;
    private float zBounds = 25f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = movementSpeed * new Vector3(horizontalInput, 0, verticalInput);
        playerRb.linearVelocity = movement;

        // Clamp the player's position within the bounds
        playerRb.position = new Vector3(
            Mathf.Clamp(playerRb.position.x, -xBounds, xBounds),
            playerRb.position.y,
            Mathf.Clamp(playerRb.position.z, -zBounds, zBounds)
        );
    }
}
