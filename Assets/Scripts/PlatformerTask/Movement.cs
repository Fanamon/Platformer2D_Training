using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;

    public float Speed => _speed;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        _rigidbody.freezeRotation = true;
    }

    public void MoveLeft()
    {
        if (_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
        }

        transform.Translate(_speed * Time.deltaTime * (-1), 0, 0);
    }

    public void MoveRight()
    {
        if (_spriteRenderer.flipX == false)
        {
            _spriteRenderer.flipX = true;
        }

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
