using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private float _attackDamage = 20f;

    private List<Enemy> _hitEnemies;
    private List<Collider2D> _hit;

    private void OnEnable()
    {
        _player.OnPreferAttack += Attack;
    }

    private void OnDisable()
    {
        _player.OnPreferAttack -= Attack;
    }

    private void Attack()
    {
        if (TryGetComponent(out Animator animator))
        {
            animator.SetTrigger("Hit");
        }

        _hit = Physics2D.OverlapCircleAll(_player.transform.position, _attackRange).ToList();
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

    private float DealDamage()
    {
        return _attackDamage;
    }
}