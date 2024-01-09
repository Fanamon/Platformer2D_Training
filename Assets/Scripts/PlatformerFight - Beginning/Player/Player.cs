using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IHealeable
{
    [SerializeField] private float _health;

    private float _maxHealth;

    private void Awake()
    {
        _maxHealth = TryGetValidated(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= TryGetValidated(damage);

        if (_health <= 0)
        {
            _health = 0;
            Destroy(gameObject);
        }
    }

    public void TakeHeal(float heal)
    {
        _health += TryGetValidated(heal);

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private float TryGetValidated(float value)
    {
        if (value < 0)
        {
            throw new System.IndexOutOfRangeException("Value less than null!");
        }

        return value;
    }
}
