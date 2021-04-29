using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootingArea : MonoBehaviour
{
    private BasePlayerController _moveController;

    [SerializeField] private List<Enemy> _enemyList;
    [Space]
    [SerializeField] private BasePlayerController _shootController;

    public event Action PlayerMissionCompleted;

    private void OnEnable()
    {
        foreach (var enemy in _enemyList)
        {
            enemy.Hitted += OnEnemyHitted;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemyList)
        {
            enemy.Hitted -= OnEnemyHitted;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_enemyList.All(enemy => enemy.IsHit))
            return;

        var rb = other.attachedRigidbody;

        if (rb == null)
            return;

        _moveController = rb.GetComponent<BasePlayerController>();

        if (_moveController == null)
            return;

        _moveController.Disable();
        _shootController.Enable();
    }

    public void Exit()
    {
        _shootController.Disable();
        _moveController.Enable();
        PlayerMissionCompleted?.Invoke();
    }

    private void OnEnemyHitted(Enemy hittedEnemy)
    {
        foreach (var enemy in _enemyList)
        {
            if (!enemy.IsHit)
                return;
        }

        Exit();
    }
}
