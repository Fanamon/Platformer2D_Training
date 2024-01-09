using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;

    public float Speed => _speed;

    private void Start()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        _rigidbody.freezeRotation = true;
    }

    public void MoveLeft()
    {
        _transform.rotation = new Quaternion(0, 180, 0, 0);

        MoveForward();
    }

    public void MoveRight()
    {
        _transform.rotation = new Quaternion(0, 0, 0, 0);

        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
        }
    }
}
