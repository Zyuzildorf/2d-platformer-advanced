using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private int _coinsCollected;
   
    public event Action OnPreferAttack;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnPreferAttack?.Invoke();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _coinsCollected++;

            Debug.Log("Монеток собрано: " + _coinsCollected);

            Destroy(other.gameObject);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}