using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private StarterAssetsInputs inputs;

    [SerializeField]
    private GameObject settingsMenu;

    private void Start()
    {
        inputs.pauseEvent.AddListener(TogglePause);
    }

    private void TogglePause()
    {
        settingsMenu.SetActive(inputs.gamePaused);
        Time.timeScale = inputs.gamePaused? 0f : 1f;
    }
}
