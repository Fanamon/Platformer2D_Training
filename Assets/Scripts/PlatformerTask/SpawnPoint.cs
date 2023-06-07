using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();

    private Animator _animator;

    private bool _isEmpty;

    public bool IsEmpty => _isEmpty;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _isEmpty = true;
    }

    public void OpenToSpawn()
    {
        _isEmpty = true;
    }

    public void CloseToSpawn()
    {
        _isEmpty = false;
    }

    public void InvokeEvent()
    {
        _animator.SetTrigger(AnimatorTriggerNames.Reached);

        _reached.Invoke();
    }
}
