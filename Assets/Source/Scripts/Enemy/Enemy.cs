using UnityEngine;

[RequireComponent(typeof(EnemyAnimationController))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private EnemyAnimationController  _animationController;

    private void Awake()
    {
        _animationController = GetComponent<EnemyAnimationController>();
    }

    public void TakeDamage(int damage)
    {
        if (TryGetComponent(out Animator animator))
        {
            _animationController.GetHit();
        } 
        
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