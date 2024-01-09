using UnityEngine;

public class Meat : MonoBehaviour
{
    [SerializeField] private float _healingValue;

    private SpawnPoint _spawnPoint;

    private void Awake()
    {
        if (_healingValue < 0)
        {
            throw new System.ArgumentOutOfRangeException("Healing cannot be less than null!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _spawnPoint.InvokeEvent();
            _spawnPoint.OpenToSpawn();

            player.TakeHeal(_healingValue);
            Destroy(gameObject);
        }
    }

    public void TakeSpawnPoint(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
}
