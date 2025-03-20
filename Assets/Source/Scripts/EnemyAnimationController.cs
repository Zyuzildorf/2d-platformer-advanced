using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    
    private Animator _animator;
    
    private void Awake()
    {
        if (TryGetComponent(out Animator animator))
        {
            _animator = animator;
        }
    }

    private void OnEnable()
    {
        _enemyMover.OnMoving += RestartWalkAnimation;
        _enemyMover.OnStopMoving += StopWalkAnimation;
        _enemyMover.OnChasing += RestartRunAnimation;
        _enemyMover.OnStopChasing += StopRunAnimation;

    }

    private void OnDisable()
    {
        _enemyMover.OnMoving -= RestartWalkAnimation;
        _enemyMover.OnStopMoving -= StopWalkAnimation;
        _enemyMover.OnChasing -= RestartRunAnimation;
        _enemyMover.OnStopChasing -= StopRunAnimation;
    }

    private void RestartWalkAnimation()
    {
        _animator.SetBool("IsWalking", true); 
    }

    private void StopWalkAnimation()
    {
        _animator.SetBool("IsWalking", false); 
    }

    private void RestartRunAnimation()
    {
        _animator.SetBool("IsRunning", true);
    }

    private void StopRunAnimation()
    {
        _animator.SetBool("IsRunning", false);
    }
}