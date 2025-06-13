using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerConfig _config;
    private Vector2 _movementInput;
    private Rigidbody2D _rb2d;

    public void Initialize(PlayerConfig config)
    {
        _config = config;
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rb2d.linearVelocity = _movementInput.normalized * _config.Speed;
    }
}
