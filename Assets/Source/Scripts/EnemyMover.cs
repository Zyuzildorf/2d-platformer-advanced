using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Waypoints _waypoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _chaseSpeed;
    [SerializeField] private float _detectionRange = 20f;

    private int _currentWaypoint;
    private bool _isMoving = false;
    private bool _isChasing = false;

    public event Action OnMoving;
    public event Action OnStopMoving;
    public event Action OnChasing;
    public event Action OnStopChasing;

    private void Update()
    {
        if (CanSeePlayer())
        {
            if (!_isChasing)
            {
                OnChasing?.Invoke();
                _isChasing = true;
                _isMoving = false;
            }
            Chase();
        }
        else
        {
            if (_isChasing)
            {
                OnStopChasing?.Invoke();
                _isChasing = false;
            }
            Patrol();
        }
    }

    private bool CanSeePlayer()
    {
        if (Vector2.Distance(transform.position, _player.position) <= _detectionRange)
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _detectionRange);

            if (hit.collider != null && hit.collider.TryGetComponent(out Player player))
            {
                Debug.Log("Игрок найден");
                return true;
            }
        }

        return false;
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            _player.position, _chaseSpeed * Time.deltaTime);
    }
    
    private void Patrol()
    {
        float distanceToWaypoint = Vector2.Distance(transform.position, 
            _waypoints.WaypointsArray[_currentWaypoint].position);

        if (distanceToWaypoint < 0.1f)
        {
            if (_isMoving)
            {
                OnStopMoving?.Invoke();
                _isMoving = false;
            }
            
            _currentWaypoint = ++_currentWaypoint % _waypoints.WaypointsArray.Length;
        }
        else
        {
            if (!_isMoving)
            {
                OnMoving?.Invoke();
                _isMoving = true;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            _waypoints.WaypointsArray[_currentWaypoint].position,
            _moveSpeed * Time.deltaTime);

        OnMoving?.Invoke();
    }
}