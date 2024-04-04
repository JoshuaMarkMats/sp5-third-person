using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField]
    private StarterAssetsInputs inputs;
    [SerializeField]
    private UIController _uiController;

    [HideInInspector]
    public UnityEvent PauseEvent;
    [HideInInspector]
    public UnityEvent GameOverEvent;

    public bool GamePaused { get; private set; } = false;
    public bool IsGameOver { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void TogglePause()
    {
        GamePaused = !GamePaused;
        Time.timeScale = GamePaused? 0f : 1f;
        PauseEvent?.Invoke();
    }

    public void GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0f;
        GameOverEvent?.Invoke();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Stats.Instance.ChineseTakeout = 0;
        SceneLoader.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        SceneLoader.LoadScene("MainMenu");
    }
}
