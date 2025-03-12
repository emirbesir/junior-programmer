using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10.0f;
    [Header("Bounds")]
    [SerializeField] private float xBounds = 25f;
    [SerializeField] private float zBounds = 25f;

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
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }
    void GetInput()
    {
        // Get the player's input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    void MovePlayer()
    {
        // Move the player based on the input
        Vector3 movement = movementSpeed * new Vector3(horizontalInput, 0, verticalInput);
        playerRb.linearVelocity = movement;
    }

    void ConstrainPlayerPosition()
    {
        // Clamp the player's position within the bounds
        playerRb.position = new Vector3(
            Mathf.Clamp(playerRb.position.x, -xBounds, xBounds),
            playerRb.position.y,
            Mathf.Clamp(playerRb.position.z, -zBounds, zBounds)
        );
    }
}
