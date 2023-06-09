using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Movement))]
public class KeyboardInput : MonoBehaviour
{
    private Animator _animator;
    private Movement _movement;

    private readonly float _idleSpeed = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
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
