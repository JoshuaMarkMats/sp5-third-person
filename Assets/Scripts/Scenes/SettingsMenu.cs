using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
            SceneLoader.LoadScene("MainMenu");
        else
            MenuManager.OpenMenu(Menu.MAIN, gameObject);
    }
}
