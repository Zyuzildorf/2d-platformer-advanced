public class PlayerHealth : Health
{
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