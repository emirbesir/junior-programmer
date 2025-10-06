using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cam;

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float xBounds = 25f;
    [SerializeField] private float zBounds = 25f;

    private Rigidbody rb;
    private float turnSmoothVelocity;
    private Vector3 inputDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        ClampPosition();
    }

    private void HandleMovement()
    {
        if (inputDirection.sqrMagnitude < 0.01f)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, smoothedAngle, 0);

        Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        rb.linearVelocity = moveDir.normalized * movementSpeed;
    }

    private void ClampPosition()
    {
        Vector3 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, -xBounds, xBounds);
        pos.z = Mathf.Clamp(pos.z, -zBounds, zBounds);
        rb.position = pos;
    }
}