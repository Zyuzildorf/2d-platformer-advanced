using UnityEngine;

[RequireComponent(typeof(EnemyPatroler), typeof(EnemyAnimationsSetter),typeof(EnemyHealth) )]
[RequireComponent(typeof(EnemyChaser), typeof(EnemyAttacker))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerSearcher _playerSearcher;
    [SerializeField] private int _health;

    private bool _isPatrolling;
    private bool _isChasing;
    private EnemyHealth _enemyHealth;
    private EnemyChaser _enemyChaser;
    private EnemyPatroler _enemyPatrol;
    private EnemyAttacker _enemyAttacker;
    private EnemyAnimationsSetter _enemyAnimationsSetter;

    public EnemyHealth EnemyHealth => _enemyHealth;
    
    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyChaser = GetComponent<EnemyChaser>();
        _enemyPatrol = GetComponent<EnemyPatroler>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
        _playerSearcher = GetComponent<PlayerSearcher>();
        _enemyAnimationsSetter = GetComponent<EnemyAnimationsSetter>();
    }

    private void OnEnable()
    {
        _enemyAttacker.Attacking += _enemyAnimationsSetter.Attack;
        _enemyHealth.DamageTaken += _enemyAnimationsSetter.GetHit;
        _enemyHealth.RanOutOfHealth += Die;
    }

    private void Update()
    {
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

            _enemyAttacker.Attack(_playerSearcher.FindedPlayer.PlayerHealth);
        }
    }
    
    private void OnDisable()
    {
        _enemyAttacker.Attacking -= _enemyAnimationsSetter.Attack;
        _enemyHealth.DamageTaken -= _enemyAnimationsSetter.GetHit;
        _enemyHealth.RanOutOfHealth -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}