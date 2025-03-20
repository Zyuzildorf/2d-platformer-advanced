using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeartSpawner : MonoBehaviour
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private List<Transform> _spawnpoints;
    [SerializeField] private int _preferHearthAmount;

    private List<int> _randomSpawnpointsIndexes;
    private int _randomSpawnpointIndex;

    private void Awake()
    {
        _randomSpawnpointsIndexes = new List<int>();
    }

    private void Start()
    {
        if (_preferHearthAmount > _spawnpoints.Count)
        {
            _preferHearthAmount = _spawnpoints.Count;
        }

        SpawnMedChestInRandomPoints();
    }

    private void SpawnMedChestInRandomPoints()
    {
        GetRandomSpawnPoints();

        for (int i = 0; i < _randomSpawnpointsIndexes.Count; i++)
        {
            Instantiate(_heartPrefab, _spawnpoints[_randomSpawnpointsIndexes[i]].position, Quaternion.identity);
        }
    }

    private void GetRandomSpawnPoints()
    {
        for (int i = 0; i < _preferHearthAmount; i++)
        {
            _randomSpawnpointIndex = Random.Range(0, _spawnpoints.Count);

            if (_randomSpawnpointsIndexes.Contains(_randomSpawnpointIndex) == false)
            {
                _randomSpawnpointsIndexes.Add(_randomSpawnpointIndex);
            }
            else
            {
                --i;
            }
        }
    }
}