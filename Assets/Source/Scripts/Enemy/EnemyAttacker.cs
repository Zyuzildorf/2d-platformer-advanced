using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimationController))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private PlayerSearcher _playerSearcher;
    [SerializeField] private int _attackDamage = 20;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDelay = 2f;

    private bool _canAttack = true;
    private List<Collider2D> _hit;
    private EnemyAnimationController _animatior;

    private void Awake()
    {
        _animatior = GetComponent<EnemyAnimationController>();
    }

    private void Update()
    {
        if (_playerSearcher.FindedPlayer != null && Vector2.Distance(_playerSearcher.FindedPlayer.transform.position, transform.position) <= _attackDistance)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (_canAttack == false)
            return;

        _canAttack = false;
        Invoke(nameof(CanAttack), _attackDelay);

        _animatior.Attack();

        _playerSearcher.FindedPlayer.TakeDamage(DealDamage());
    }

    private int DealDamage()
    {
        return _attackDamage;
    }

    private void CanAttack()
    {
        _canAttack = true;
    }
}