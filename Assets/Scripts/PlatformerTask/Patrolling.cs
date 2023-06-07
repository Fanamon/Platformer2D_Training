using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private int _currentPoint;

    private Transform[] _points;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        ChangeFlipXPosition(target);

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void ChangeFlipXPosition(Transform target)
    {
        if (target.position.x >= transform.position.x && _spriteRenderer.flipX == false)
        {
            _spriteRenderer.flipX = true;
        }
        else if (target.position.x < transform.position.x && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
