using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void ReturnToMain()
    {
        MenuManager.OpenMenu(Menu.MAIN, gameObject);
    }
}
