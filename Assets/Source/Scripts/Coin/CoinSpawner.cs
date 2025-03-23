using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnpoints;

    private Coin newCoin;
    
    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnpoints.Length; i++)
        {
            newCoin = Instantiate(_coinPrefab, _spawnpoints[i].position, Quaternion.identity);

            newCoin.OnCollected += DestroyCoin;
        }        
    }

    private void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
        
        coin.OnCollected -= DestroyCoin;
    }
}