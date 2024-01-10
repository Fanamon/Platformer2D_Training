using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform _playableModel;

    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;

    public float Speed => _speed;

    private void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        _rigidbody.freezeRotation = true;
    }

    public void MoveLeft()
    {
        _playableModel.rotation = new Quaternion(0, 180, 0, 0);
        _transform.Translate(_speed * -Time.deltaTime, 0, 0);
    }

    public void MoveRight()
    {
        _playableModel.rotation = new Quaternion(0, 0, 0, 0);
        _transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
        }
    }
}
