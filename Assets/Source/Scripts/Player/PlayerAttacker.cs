using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(InputReader),typeof(PlayerAnimationController))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private int _attackDamage = 20;

    private PlayerAnimationController _animator;
    private InputReader _inputReader;
    private List<Enemy> _hitEnemies;
    private List<Collider2D> _hit;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _animator = GetComponent<PlayerAnimationController>();
    }

    private void Update()
    {
        if (_inputReader.OnMouseButtonPressed)
        {
            Attack();
        }
    }

    private void Attack()
    {
        _animator.Attack();

        _hit = Physics2D.OverlapCircleAll(transform.position, _attackRange).ToList();
        _hitEnemies = new List<Enemy>();
        
        for (int i = 0; i < _hit.Count; i++)
        {
            if (_hit[i].TryGetComponent(out Enemy enemy))
            {
                _hitEnemies.Add(enemy);
            }
        }

        foreach (Enemy enemy in _hitEnemies)
        {
            enemy.TakeDamage(DealDamage());
        }
    }

    private int DealDamage()
    {
        return _attackDamage;
    }
}