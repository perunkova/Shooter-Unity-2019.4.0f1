using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] Button _restartButton;

    void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }
    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
