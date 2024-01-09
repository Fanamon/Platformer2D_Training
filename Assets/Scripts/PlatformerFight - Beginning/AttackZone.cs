using UnityEngine;

public class AttackZone : MonoBehaviour
{
    private float _attackValue;

    public void SetAttackValue(float attack)
    {
        if (attack < 0)
        {
            throw new System.ArgumentOutOfRangeException("Damage cannot be less than null!");
        }

        _attackValue = attack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_attackValue);
        }
    }
}
