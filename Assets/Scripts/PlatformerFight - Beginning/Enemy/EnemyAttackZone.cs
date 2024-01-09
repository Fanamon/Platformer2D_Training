using UnityEngine;

public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] private EnemyAttack _enemyAttack;

    private void Awake()
    {
        _enemyAttack.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _enemyAttack.enabled = true;
            _enemyAttack.StartFight(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _enemyAttack.FinishFight();
            _enemyAttack.enabled = false;
        }
    }
}
