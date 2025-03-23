using UnityEngine;

public class PlayerSearcher : MonoBehaviour
{
    [SerializeField] private float _distanceRaycast;
    [SerializeField] private float _maxYDistance;
    [SerializeField] private Transform _lookAtTransform;
    [SerializeField] private LayerMask _layerMask;

    private Vector2 _direction;
    private RaycastHit2D _hit;
    
    public Player FindedPlayer { get; private set; }

    public void FindPlayer()
    {
        _direction = (_lookAtTransform.position - transform.position).normalized;
        _hit = Physics2D.Raycast(transform.position, _direction, _distanceRaycast, _layerMask);

        if (_hit.collider != null && _hit.collider.TryGetComponent(out Player player) && player.transform.position.y - transform.position.y <= _maxYDistance)
        {
            FindedPlayer = player;
            return;
        }

        FindedPlayer = null;
    }
}