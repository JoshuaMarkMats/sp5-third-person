using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField]
    private GameObject _gameUI;
    [SerializeField]
    private string _label = "Chinese Takeout Retrieved";
    [SerializeField]
    private TextMeshProUGUI _chineseTakeoutCounterText;
    public SpeechBox speechBox;

    [Space()]

    [SerializeField]
    private GameObject _pauseScreen;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateUI();

        GameController.Instance.PauseEvent.AddListener(TogglePause);

        Stats.Instance.StatsUpdatedEvent.AddListener(UpdateUI);

        MenuManager.Init();
        _pauseScreen.SetActive(false);
    }

    private void UpdateUI()
    {
        _chineseTakeoutCounterText.text = $"{_label}: {Stats.Instance.ChineseTakeout}";
    }

    private void TogglePause()
    {
        bool gamePaused = GameController.Instance.GamePaused;

        Cursor.lockState = gamePaused ? CursorLockMode.None : CursorLockMode.Locked;

        _gameUI.SetActive(!gamePaused);
        _pauseScreen.SetActive(gamePaused);
    }
}
