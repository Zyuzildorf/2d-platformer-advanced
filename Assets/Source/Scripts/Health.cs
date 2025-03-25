using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _health;
    
    protected int _maxHealth;

    public event Action RanOutOfHealth;
    
    private void Awake()
    {
        _maxHealth = _health;
    }
    
    public virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }
        
        _health -= damage;
        
        if (_health <= 0)
        {
            RanOutOfHealth?.Invoke();
        }
    }
}