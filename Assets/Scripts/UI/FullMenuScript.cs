using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            MenuManager.Init();
        }
    }
}
