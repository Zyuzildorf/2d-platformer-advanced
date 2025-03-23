using UnityEngine;

[RequireComponent(typeof(EnemyPatroler), typeof(EnemyAnimationsSetter), typeof(PlayerSearcher))]
[RequireComponent(typeof(EnemyChaser), typeof(EnemyAttacker))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private EnemyAnimationsSetter _enemyAnimationsSetter;
    private EnemyPatroler _enemyPatrol;
    private EnemyChaser _enemyChaser;
    private EnemyAttacker _enemyAttacker;
    private PlayerSearcher _playerSearcher;
    private bool _isPatrolling;
    private bool _isChasing;

    private void Awake()
    {
        _enemyAnimationsSetter = GetComponent<EnemyAnimationsSetter>();
        _enemyPatrol = GetComponent<EnemyPatroler>();
        _enemyChaser = GetComponent<EnemyChaser>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
        _playerSearcher = GetComponent<PlayerSearcher>();
    }

    private void OnEnable()
    {
        _enemyAttacker.OnAttacking += _enemyAnimationsSetter.Attack;
    }

    private void OnDisable()
    {
        _enemyAttacker.OnAttacking -= _enemyAnimationsSetter.Attack;
    }

    private void Update()
    {
        _playerSearcher.FindPlayer();

        if (_playerSearcher.FindedPlayer == null)
        {
            _enemyAnimationsSetter.StopChaseAnimation();

            _enemyPatrol.Patrol();

            if (_enemyPatrol.IsTargetReached == false)
            {
                _enemyAnimationsSetter.RestartWalkAnimation();
            }
            else
            {
                _enemyAnimationsSetter.StopWalkAnimation();
            }
        }
        else
        {
            _enemyAnimationsSetter.StopWalkAnimation();
            _enemyAnimationsSetter.RestartChaseAnimation();

            _enemyChaser.Chase(_playerSearcher.FindedPlayer.transform.position);

            _enemyAttacker.Attack(_playerSearcher.FindedPlayer);
        }
    }

    public void TakeDamage(int damage)
    {
        _enemyAnimationsSetter.GetHit();

        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}