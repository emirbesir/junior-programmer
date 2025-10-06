using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatVariable _moveSpeed;
    [SerializeField] private Animator _animator;

    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int isMoving = Animator.StringToHash("IsMoving");

    private Vector2 _movementInputNormalized;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadMovementInputNormalized();
        SetAnimatorParameters();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void ReadMovementInputNormalized()
    {
        _movementInputNormalized = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void SetAnimatorParameters()
    {
        if (_movementInputNormalized == Vector2.zero)
        {
            _animator.SetBool(isMoving, false);
            return;
        }

        _animator.SetBool(isMoving, true);
        _animator.SetFloat(moveX, _movementInputNormalized.x);
        _animator.SetFloat(moveY, _movementInputNormalized.y);
    }

    private void MovePlayer()
    {
        _rb2d.linearVelocity = _movementInputNormalized * _moveSpeed.Value;
    }
}
