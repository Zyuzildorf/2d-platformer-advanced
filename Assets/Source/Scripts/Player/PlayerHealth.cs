using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    
    private int _maxHealth;
    
    private void Awake()
    {
        _maxHealth = _health;
    }
    
    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }
        
        _health -= damage;
        
        if (_health <= 0)
        {
            Die();
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
    
    private void Die()
    {
        Destroy(gameObject);
    }
}