using UnityEngine;

[RequireComponent(typeof(ItemsCollector))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _money;
    private int _maxHealth;
    private ItemsCollector _itemsCollector;
    private InputReader _inputReader;
    private PlayerMover _playerMover;
    private PlayerJumper _playerJumper;
    private PlayerGroundDetector _playerGroundDetector;
    private PlayerAttacker _playerAttacker;
    private PlayerAnimationsSetter _playerAnimationSetter;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;

        Debug.Log("Получено " + damage + "урона.\n Осталось: " + _health + " здоровья.");
        
        if (_health <= 0)
        {
            Die();
        }
    }
    
    private void Awake()
    {
        _maxHealth = _health;
        _itemsCollector = GetComponent<ItemsCollector>();
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _playerJumper = GetComponent<PlayerJumper>();
        _playerGroundDetector = GetComponent<PlayerGroundDetector>();
        _playerAnimationSetter = GetComponent<PlayerAnimationsSetter>();
        _playerAttacker = GetComponent<PlayerAttacker>();
    }
    

    private void OnEnable()
    {
        _itemsCollector.OnHearthCollected += HealthRecover;
        _itemsCollector.OnCoinCollected += TakeCoin;
        _playerAttacker.OnAttacking += _playerAnimationSetter.Attack;
    }

    private void Update()
    {
        if (_inputReader.Direction != 0)
        {
            _playerMover.Move(_inputReader.Direction);
            _playerAnimationSetter.RestartRunAnimation();
        }
        else
        {
            _playerAnimationSetter.StopRunAnimation();
        }

        if (_inputReader.OnSpacebarPressed && _playerGroundDetector.IsGrounded)
        {
            _playerJumper.Jump();
        }

        if (_inputReader.OnMouseButtonPressed)
        {
            _playerAttacker.Attack();
        }
    }

    private void OnDisable()
    {
        _itemsCollector.OnHearthCollected -= HealthRecover;
        _itemsCollector.OnCoinCollected -= TakeCoin;
        _playerAttacker.OnAttacking -= _playerAnimationSetter.Attack;
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

    private void Die()
    {
        Destroy(gameObject);
    }
}