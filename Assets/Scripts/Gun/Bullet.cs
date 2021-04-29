using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _transform;
    private Coroutine _moveRoutine;
    private Coroutine _waitRoutine;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private Rigidbody _rbBullet;
    [SerializeField] private ParticleSystemEffectController _psEffectController;

    public event Action<Bullet> BulletMissionCompleted;
    public BulletPowerSettings BulletPowerSettings;

    private void Awake()
    {
        _transform = transform;
    }

    public void Move()
    {
        _moveRoutine = StartCoroutine(MoveRoutine());
        _waitRoutine = StartCoroutine(WaitRoutine(BulletMissionComplete));
    }

    private void StopRoutine()
    {
        if (_moveRoutine != null)
            StopCoroutine(_moveRoutine);

        if (_waitRoutine != null)
            StopCoroutine(_waitRoutine);
    }

    private void BulletMissionComplete()
    {
        StopRoutine();
        BulletMissionCompleted?.Invoke(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = UnityComponentHelper.GetComponentInParents<Enemy>(collision.transform);

        if (enemy != null)
        {
            collision.rigidbody.AddForceAtPosition(BulletPowerSettings.BulletPower * transform.forward, collision.contacts[0].point, ForceMode.Impulse);
            enemy.IsHit = true;
        }

        StopRoutine();
        _psEffectController.PlayEffect(() => BulletMissionCompleted?.Invoke(this));
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            _rbBullet.MovePosition(_transform.position + _transform.forward * Time.deltaTime * _speed);

            yield return null;
        }
    }

    private IEnumerator WaitRoutine(Action callback)
    {
        yield return new WaitForSeconds(4);

        callback?.Invoke();
    }
}
