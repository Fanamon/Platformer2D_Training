using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private const float DoubleMultipliyer = 0.5f;

    [SerializeField] private float _attackValue;
    [SerializeField] private AttackZone _attackZone;

    private Coroutine _attacker = null;

    private void Awake()
    {
        _attackZone.SetAttackValue(_attackValue);
    }

    public void Punch(float attackInterval)
    {
        if (_attacker != null)
        {
            StopCoroutine(_attacker);
        }

        _attacker = StartCoroutine(Attack(attackInterval));
    }

    private IEnumerator Attack(float attackInterval)
    {
        yield return new WaitForSeconds(attackInterval * DoubleMultipliyer);

        _attackZone.gameObject.SetActive(true);

        yield return new WaitForSeconds(attackInterval * DoubleMultipliyer);

        _attackZone.gameObject.SetActive(false);
        _attacker = null;
    }
}