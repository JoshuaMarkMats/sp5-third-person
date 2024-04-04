using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneLoader.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
