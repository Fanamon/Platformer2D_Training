using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private const string Attack = "KnightAttack";

    [SerializeField] private float _damage;

    [SerializeField] private Animator _animator;

    private float _attackClipTime;

    private Coroutine _attacker;

    private void Awake()
    {
        _attackClipTime = _animator.runtimeAnimatorController.animationClips.
            First(clip => clip.name == Attack).length;
    }

    private void OnEnable()
    {
        _attacker = null;
    }

    public void StartFight(Player player)
    {
        if (_attacker == null)
        {
            _attacker = StartCoroutine(Fight(player));
        }
    }

    public void FinishFight()
    {
        if (_attacker != null)
        {
            StopCoroutine(_attacker);
        }

        _attacker = null;
    }

    private IEnumerator Fight(Player player)
    {
        player.TakeDamage(_damage);
        _animator.SetTrigger(AnimatorTriggerNames.Attack);

        yield return new WaitForSeconds(_attackClipTime);

        _attacker = null;
    }
}
