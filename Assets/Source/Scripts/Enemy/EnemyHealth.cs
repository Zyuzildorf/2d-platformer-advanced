using System;

public class EnemyHealth : Health
{
    public event Action DamageTaken;
    
    public override void TakeDamage(int damage)
    {
        DamageTaken?.Invoke();
        
        base.TakeDamage(damage);
    }
}