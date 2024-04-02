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
    public GameObject interactBoxObject;
    public TextMeshProUGUI interactText;

    [Space()]

    [SerializeField]
    private GameObject _pauseScreen;
    [SerializeField]
    private GameObject _gameOverScreen;

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
        GameController.Instance.GameOverEvent.AddListener(OnGameOver);

        Stats.Instance.StatsUpdatedEvent.AddListener(UpdateUI);

        MenuManager.Init();
        _pauseScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
        interactBoxObject.SetActive(false);
    }

    private void UpdateUI()
    {
        _chineseTakeoutCounterText.text = $"{_label}: {Stats.Instance.ChineseTakeout}";
    }

    public void ShowInteract(string message)
    {
        if (message == "")
            interactBoxObject.SetActive(false);
        else
        {
            interactBoxObject.SetActive(true);
            interactText.text = message;
        }
    }

    private void OnGameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        _gameUI.SetActive(false);
        _gameOverScreen.SetActive(true);
    }

    private void TogglePause()
    {
        bool gamePaused = GameController.Instance.GamePaused;

        Cursor.lockState = gamePaused ? CursorLockMode.None : CursorLockMode.Locked;

        _gameUI.SetActive(!gamePaused);
        _pauseScreen.SetActive(gamePaused);
    }
}
