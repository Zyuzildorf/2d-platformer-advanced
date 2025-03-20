using UnityEngine;

[RequireComponent(typeof(InputReader),typeof(Rigidbody2D),typeof(Animator))]
[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private InputReader _inputReader;
    private PlayerAnimationController _playerAnimationController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
        _playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_inputReader.MoveInput != 0)
        {
            _playerAnimationController.RestartRunAnimation();
        }
        else
        {
            _playerAnimationController.StopRunAnimation();
        }

        _rigidbody.velocity = new Vector2(_inputReader.MoveInput * _moveSpeed, _rigidbody.velocity.y);
    }
}