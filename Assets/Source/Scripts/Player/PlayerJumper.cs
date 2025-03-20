using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    
    private Rigidbody2D _rigidbody;
    private InputReader _inputReader;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (_inputReader.OnSpacebarPressed && _isGrounded)
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