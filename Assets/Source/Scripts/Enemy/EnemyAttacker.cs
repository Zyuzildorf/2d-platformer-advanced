using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _attackDamage = 20;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDelay = 2f;

    private WaitForSeconds _waitForSeconds;
    private List<Collider2D> _hit;
    private bool _isAttackDelayOver;

    public event Action OnAttacking;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_attackDelay);
        _isAttackDelayOver = true;
    }

    public void Attack(Player player)
    {
        if (_isAttackDelayOver == false)
            return;

        if (CheckAttackPossibility(player.transform.position))
        {
            OnAttacking?.Invoke();
            player.TakeDamage(DealDamage());
        }

        StartCoroutine(WaitForNextAttack());
    }

    private bool CheckAttackPossibility(Vector3 target)
    {
        if (Vector2.Distance(target, transform.position) <= _attackDistance)
        {
            return true;
        }

        return false;
    }

    private int DealDamage()
    {
        return _attackDamage;
    }

    private IEnumerator WaitForNextAttack()
    {
        _isAttackDelayOver = false;
        yield return _waitForSeconds;
        _isAttackDelayOver = true;
    }
}