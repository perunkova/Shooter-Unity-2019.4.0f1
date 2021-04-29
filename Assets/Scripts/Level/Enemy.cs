using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isHit = false;

    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Animator _animator;

    public event Action<Enemy> Hitted;

    private void Awake()
    {
        EnablePhysic(false);
    }

    private void Reset()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void EnablePhysic(bool value)
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
            _rigidbodies[i].isKinematic = !value;
    }

    public bool IsHit
    {
        get
        {
            return _isHit;
        }
        set
        {
            _isHit = value;
            if (_isHit)
            {
                _animator.enabled = false;
                EnablePhysic(true);
                Hitted?.Invoke(this);
            }
        }
    }
}
