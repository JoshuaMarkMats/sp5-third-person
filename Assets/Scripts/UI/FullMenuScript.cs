using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FullMenuScript : MonoBehaviour
{
    [SerializeField]
    private int _musicIndex = 0;
    [SerializeField]
    private bool _isMenu = true;

    private void Start()
    {
        AudioController.Instance.SetBackgroundMusic(_musicIndex);

        if (_isMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            if (SceneManager.GetSceneByName("EndScreen") != SceneManager.GetActiveScene()) //hacky fix for lack of menumanager at the end
                MenuManager.Init();
        }
    }
}
