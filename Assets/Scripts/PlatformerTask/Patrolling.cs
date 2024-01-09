using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private EnemyVisionZone _enemyVisionZone;
    [SerializeField] private float _speed;

    private Transform _transform;
    private Vector3 _target;
    private Rigidbody2D _rigidbody;

    private int _currentPoint;

    private Transform[] _points;

    private void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        if (_enemyVisionZone.IsPlayerInVisionZone == false)
        {
            _target = _points[_currentPoint].position;
        }
        else
        {
            _target = _enemyVisionZone.PlayerPosition.position;
        }

        ChangeFlipXPosition(_target);

        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (_transform.position == _target)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void ChangeFlipXPosition(Vector3 target)
    {
        if (target.x >= transform.position.x)
        {
            _transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (target.x < transform.position.x)
        {
            _transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
}
