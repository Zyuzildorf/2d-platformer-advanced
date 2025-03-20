using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isGrounded;
    private float _moveInput;

    private void Awake()
    {
        if (_player.TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            _rigidbody = rigidbody2D;
        }
        
        if (_player.TryGetComponent(out Animator animator))
        {
            _animator = animator;
        }
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _moveInput = Input.GetAxis("Horizontal");
        
        if (_moveInput != 0)
        {
            _animator.SetBool("IsWalking", true); 
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }

        _rigidbody.velocity = new Vector2(_moveInput * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
           _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isGrounded = false;
    }
}