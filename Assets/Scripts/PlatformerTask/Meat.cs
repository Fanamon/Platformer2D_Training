using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    private SpawnPoint _spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _spawnPoint.InvokeEvent();

            _spawnPoint.OpenToSpawn();

            Destroy(gameObject);
        }
    }

    public void TakeSpawnPoint(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
}
