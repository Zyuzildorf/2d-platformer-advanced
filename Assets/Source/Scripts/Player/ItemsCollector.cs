using System;
using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
    public event Action<int> OnHearthCollected; 
    public event Action<int> OnCoinCollected; 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            OnCoinCollected?.Invoke(coin.CoinValue);
            coin.CallEvent();
        }

        if (other.TryGetComponent(out Heart heart))
        {
            OnHearthCollected?.Invoke(heart.HealtAmount);
            heart.CallEvent();
        }
    }
}