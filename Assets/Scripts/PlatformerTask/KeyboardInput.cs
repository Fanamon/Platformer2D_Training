using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(PlayerAttack))]
public class KeyboardInput : MonoBehaviour
{
    private const string Attack = "WerewolfAttack";

    private Animator _animator;
    private Movement _movement;
    private PlayerAttack _playerAttack;

    private readonly float _idleSpeed = 0;

    private float _attackClipTime;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _attackClipTime = _animator.runtimeAnimatorController.animationClips.
            First(clip => clip.name == Attack).length;
    }

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false)
        {
            _movement.MoveLeft();
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) == false)
        {
            _movement.MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movement.Jump();
        }

        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            _animator.SetTrigger(AnimatorTriggerNames.Attack);
            _playerAttack.Punch(_attackClipTime);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false ||
            Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) == false)
        {
            _animator.SetFloat(AnimatorTriggerNames.Speed, _movement.Speed);
        }
        else
        {
            _animator.SetFloat(AnimatorTriggerNames.Speed, _idleSpeed);
        }
    }
}
