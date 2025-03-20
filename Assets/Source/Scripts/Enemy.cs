using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        if (TryGetComponent(out Animator animator))
        {
            animator.SetTrigger("GetHitted");
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