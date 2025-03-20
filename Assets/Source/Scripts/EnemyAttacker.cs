using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _attackDamage = 20f;
    
    private List<Player> _hitTargets;
    private List<Collider2D> _hit;
    private bool _isTargetFound;

    private void Update()
    {
        if (SearchForTargetExist())
        {
            Attack();
        }
    }

    private bool SearchForTargetExist()
    {
        _hit = Physics2D.OverlapCircleAll(transform.position, _attackRange).ToList();
        _hitTargets = new List<Player>();
        
        for (int i = 0; i < _hit.Count; i++)
        {
            if (_hit[i].TryGetComponent(out Player player))
            {
                _hitTargets.Add(player);
            }
        }

        if (_hitTargets.Count > 0)
        {
            _isTargetFound = true;
        }
        else
        {
            _isTargetFound = false;
        }

        return _isTargetFound;
    }

    private void Attack()
    {
        if (TryGetComponent(out Animator animator))
        {
            animator.SetTrigger("GetHitted");
        }

        foreach (Player player in _hitTargets)
        {
            player.TakeDamage(DealDamage());
        }
    }

    private float DealDamage()
    {
        return _attackDamage;
    }
}