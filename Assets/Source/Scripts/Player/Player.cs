using UnityEngine;

[RequireComponent(typeof(ItemsCollector))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private ItemsCollector _itemsCollector;
    private int _money;
    private int _maxHealth;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        Debug.Log("Получено " + damage + "урона.\n Осталось: " + _health + " здоровья.");
        
        if (_health <= 0)
        {
            Die();
        }
    }

    private void OnEnable()
    {
        _itemsCollector.OnHearthCollected += HealthRecover;
        _itemsCollector.OnCoinCollected += TakeCoin;
    }

    private void OnDisable()
    {
        _itemsCollector.OnHearthCollected -= HealthRecover;
        _itemsCollector.OnCoinCollected -= TakeCoin;
    }

    private void HealthRecover(int health)
    {
        _health += health;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        
        Debug.Log("Здоровье восстановлено.\nТекущее здоровье: " + _health);
    }

    private void TakeCoin(int coinValue)
    {
        _money += coinValue;
        
        Debug.Log("Денег в кошельке: " + _money);
    }
    
    private void Awake()
    {
        _itemsCollector = GetComponent<ItemsCollector>();
        _maxHealth = _health;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}