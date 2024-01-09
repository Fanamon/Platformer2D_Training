using UnityEngine;

public class EnemyVisionZone : MonoBehaviour
{
    public Transform PlayerPosition { get; private set; }
    public bool IsPlayerInVisionZone { get; private set; }

    private void Awake()
    {
        IsPlayerInVisionZone = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            IsPlayerInVisionZone = true;
            PlayerPosition = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            IsPlayerInVisionZone = false;
        }
    }
}
