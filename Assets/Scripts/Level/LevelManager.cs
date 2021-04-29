using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private RestartMenu _restartMenu;
    [Space]
    [SerializeField] private ShootingArea _shootingArea;

    private void Awake()
    {
        _shootingArea.PlayerMissionCompleted += OpenRestartMenu;
    }

    private void OpenRestartMenu ()
    {
        _restartMenu.gameObject.SetActive(true);
    }
}
