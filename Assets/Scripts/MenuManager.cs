using UnityEditor;
using UnityEngine;

public enum Menu
{
    MAIN,
    SETTINGS,
    NONE
}

public static class MenuManager
{
    public static bool IsInitialized = false;
    public static GameObject mainMenu, settingsMenu;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;

        IsInitialized = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialized) Init();

        switch (menu)
        {
            case Menu.MAIN:
                mainMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }
}
