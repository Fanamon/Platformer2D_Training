using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour, IDamageable, IHealeable
{
    [SerializeField] private float _health;

    public event UnityAction<float> HealthChanged;

    public float MaxHealth { get; private set; }

    private void Awake()
    {
        MaxHealth = TryGetValidated(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= TryGetValidated(damage);

        if (_health <= 0)
        {
            Die();
        }

        HealthChanged?.Invoke(_health);
    }

    public void TakeHeal(float heal)
    {
        _health += TryGetValidated(heal);

        if (_health > MaxHealth)
        {
            _health = MaxHealth;
        }

        HealthChanged?.Invoke(_health);
    }

    private float TryGetValidated(float value)
    {
        if (value < 0)
        {
            throw new System.IndexOutOfRangeException("Value less than null!");
        }

        return value;
    }

    private void Die()
    {
        _health = 0;
        HealthChanged?.Invoke(_health);
        Destroy(gameObject);
    }
}
