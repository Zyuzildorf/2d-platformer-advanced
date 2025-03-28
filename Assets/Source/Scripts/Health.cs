using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _health;
    
    protected int _maxHealth;

    public event Action Defeated;
    public event Action DamageTaken;
    
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
        
        DamageTaken?.Invoke();
        
        _health -= damage;
        
        if (_health <= 0)
        {
            Defeated?.Invoke();
        }
    }
    
    public void HealthRecover(Heart heart)
    {
        if (heart.HealtAmount < 0)
        {
            return;
        }
        
        _health += heart.HealtAmount;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}