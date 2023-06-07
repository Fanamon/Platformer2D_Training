using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFX : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private AnimationCurve _scaleAnimation;
    [SerializeField] private float _height;
    [SerializeField] private ProgrammableAnimation _playtime;

    private void Awake()
    {
        _playtime = new ProgrammableAnimation(this);
    }

    /*public ProgrammableAnimation PlayAnimation(Transform jumper, float duration)
    {
        _playtime.Play(duration, (float progress) =>
        {
            Vector2 position = Vector2.Scale(new Vector2(0, _height * _yAnimation.Evaluate(progress)), jumper.up);
            Vector2 scale = Vector2.one * _scaleAnimation.Evaluate(progress);

            return new TransformChanges(position, scale);
        });

        return _playtime;
    }*/
}
