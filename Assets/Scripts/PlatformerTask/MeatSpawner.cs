using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeatSpawner : MonoBehaviour
{
    [SerializeField] private Meat _meatToSpawn;

    private readonly System.Random _random = new System.Random();

    private SpawnPoint[] _pointFillness;
    private Transform[] _spawnPoints;

    private void Start()
    {
        _pointFillness = GetComponentsInChildren<SpawnPoint>();
        _spawnPoints = GetComponentsInChildren<Transform>().Where(spawnPoint => spawnPoint != transform).ToArray();

        StartCoroutine(SpawnWithTimeInterval());
    }

    private IEnumerator SpawnWithTimeInterval()
    {
        float spawnInterval = 5;

        bool isGameGoing = true;

        while (isGameGoing)
        {
            TrySpawnMeat();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void TrySpawnMeat()
    {
        int randomSpawnIndex = _random.Next(_spawnPoints.Length);

        if (_pointFillness[randomSpawnIndex].IsEmpty)
        {
            GameObject meat = Instantiate(_meatToSpawn.gameObject,
                _spawnPoints[randomSpawnIndex].transform.position, Quaternion.identity);

            meat.GetComponent<Meat>().TakeSpawnPoint(_pointFillness[randomSpawnIndex]);

            _pointFillness[randomSpawnIndex].CloseToSpawn();
        }
    }
}
