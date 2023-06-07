using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private JumpFX _fx;
    [SerializeField] private float _length;
    [SerializeField] private float _duration;

    private ProgrammableAnimation _playTime;

    private void Awake()
    {
        _playTime = new ProgrammableAnimation(this);
    }

    /*public void Jump(Vector2 direction)
    {
        Vector2 target = transform.position + (direction * _length);
        Vector2 startPosition = transform.position;
        ProgrammableAnimation fxPlaytime = _fx.PlayAnimation(transform, _duration);

        _playTime.Play(_duration, (progress) =>
        {
            transform.position = Vector2.Lerp(startPosition, target, progress) + fxPlaytime.LastChanges.Position;
            transform.localScale = fxPlaytime.LastChanges.Scale;
            return null;
        });
    }*/
}
