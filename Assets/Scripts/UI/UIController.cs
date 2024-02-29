using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameUI;
    [SerializeField]
    private string _label = "Chinese Takeout Retrieved";
    [SerializeField]
    private TextMeshProUGUI _chineseTakeoutCounterText;

    [Space()]

    [SerializeField]
    private GameObject _pauseScreen;

    private void Start()
    {
        UpdateUI();

        GameController.Instance.PauseEvent.AddListener(TogglePause);

        Stats.Instance.StatsUpdatedEvent.AddListener(UpdateUI);
    }

    private void UpdateUI()
    {
        _chineseTakeoutCounterText.text = $"{_label}: {Stats.Instance.ChineseTakeout}";
    }

    private void TogglePause()
    {
        bool gamePaused = GameController.Instance.GamePaused;

        _gameUI.SetActive(!gamePaused);
        _pauseScreen.SetActive(gamePaused);

        if (gamePaused) MenuManager.OpenMenu(Menu.NONE);
    }

    public void OpenSettings()
    {
        MenuManager.OpenMenu(Menu.SETTINGS);
    }
}
