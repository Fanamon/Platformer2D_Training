using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammableAnimation
{
    private Coroutine _lastAnimation;
    private MonoBehaviour _context;

    public ProgrammableAnimation(MonoBehaviour context)
    {
        _context = context;
    }

    /*public TransformChanges LastChanges { get; private set; }

    public void Play(float duration, Func<float, TransformChanges> body)
    {
        if (_lastAnimation != null)
        {
            _context.StopCoroutine(_lastAnimation);
        }

        _lastAnimation = _context.StartCoroutine(GetAnimation(duration, body));
    }

    private IEnumerator GetAnimation(float duration, Func<float, TransformChanges> body)
    {
        var expiredSeconds = 0f;
        var progress = 0f;

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            LastChanges = body.Invoke(progress);

            yield return null;
        }
    }*/
}