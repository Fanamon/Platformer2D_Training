using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAttack : MonoBehaviour
{
    private const string Attack = "KnightAttack";

    [SerializeField] private float _damage;

    private float _attackClipTime;

    private Animator _animator;
    private Coroutine _attacker;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
