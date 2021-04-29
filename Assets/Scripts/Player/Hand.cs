using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private bool _shoot;
    private Coroutine _shootRoutine;

    [SerializeField] private Gun _gun;

    public ShootingSettings ShootingSettings;

    public void LookTo(Vector3 direction)
    {
        transform.forward = direction;
    }

    public void StartShoot()
    {
        _shoot = true;
        _shootRoutine = StartCoroutine(ShootRoutine());
    }

    public void StopShoot()
    {
        _shoot = false;

        if (_shootRoutine != null)
            StopCoroutine(_shootRoutine);
    }

    private IEnumerator ShootRoutine()
    {
        while (_shoot)
        {
            _gun.StartShooting();
            yield return new WaitForSeconds(ShootingSettings.ShootDelay);
        }
    }

}
