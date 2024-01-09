using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            throw new System.IndexOutOfRangeException("Damage less than null!");
        }

        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Destroy(gameObject);
        }
    }
}
