using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneLoader.LoadScene(1);
    }

    public void OpenSettings()
    {
        MenuManager.OpenMenu(Menu.SETTINGS, gameObject);
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
