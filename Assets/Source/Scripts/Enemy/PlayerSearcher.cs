using UnityEngine;

public class PlayerSearcher : MonoBehaviour
{
    [SerializeField] private float _distanceRaycast;
    [SerializeField] private float _maxYDistance;
    [SerializeField] private Transform _lookAtTransform;
    [SerializeField] private LayerMask _layerMask;

    public Player FindedPlayer { get; private set; }

    private void Update()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        Vector2 direction = (_lookAtTransform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _distanceRaycast, _layerMask);

        if (hit.collider != null && hit.collider.TryGetComponent(out Player player) && player.transform.position.y - transform.position.y <= _maxYDistance)
        {
            FindedPlayer = player;
            return;
        }

        FindedPlayer = null;
    }
}