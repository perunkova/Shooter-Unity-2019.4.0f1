using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemEffectController : MonoBehaviour
{
    private Action _callback;
    
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlayEffect(Action callback)
    {
        _callback = callback;
        _particleSystem.Play();
    }

    private void OnParticleSystemStopped()
    {
        _callback?.Invoke();
    }
}
