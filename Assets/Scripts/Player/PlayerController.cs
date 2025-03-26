using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform cam;
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    [Header("Bounds")]
    [SerializeField] private float xBounds = 25f;
    [SerializeField] private float zBounds = 25f;

    private Rigidbody playerRb;
    private Vector3 direction;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
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

    private void GetInput()
    {
        // Get the player's input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    }

    private void MovePlayer()
    {
        if (direction.magnitude >= 0.05f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Move the player based on the input
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            playerRb.linearVelocity = moveDir.normalized * movementSpeed;
        }
        else
        {
            playerRb.linearVelocity = Vector3.zero;
        }
    }

    private void ConstrainPlayerPosition()
    {
        // Clamp the player's position within the bounds
        playerRb.position = new Vector3(
            Mathf.Clamp(playerRb.position.x, -xBounds, xBounds),
            playerRb.position.y,
            Mathf.Clamp(playerRb.position.z, -zBounds, zBounds)
        );
    }
}
