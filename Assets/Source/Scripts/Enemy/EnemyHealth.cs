using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    public event Action DamageTaken;
    
    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }
        
        DamageTaken?.Invoke();
        
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