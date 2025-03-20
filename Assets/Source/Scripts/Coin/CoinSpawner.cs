using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnpoints;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnpoints.Length; i++)
        {
           Instantiate(_coinPrefab.gameObject, _spawnpoints[i].position, Quaternion.identity);
        }        
    }
}