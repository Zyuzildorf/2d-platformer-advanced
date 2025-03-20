using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SideSpriteFlipper : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _previousX;
    private float _currentX;
    private float _direction;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _previousX = transform.position.x;
    }

    public void Update()
    {
        _currentX = transform.position.x;

        if (_currentX != _previousX)
        {
            _direction = _currentX - _previousX;
            _spriteRenderer.flipX = Mathf.Sign(_direction) > 0;
            _previousX = _currentX;
        }

        _previousX = transform.position.x;
    }
}