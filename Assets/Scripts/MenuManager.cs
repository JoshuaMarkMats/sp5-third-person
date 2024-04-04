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
    private static GameObject _menuMain, _menuSettings;
    private static GameObject _activeMenu;

    public static void Init()
    {
        GameObject menuHolder = GameObject.FindGameObjectWithTag("MenuHolder");
        _menuMain = menuHolder.transform.Find("MenuMain").gameObject;
        _menuSettings = menuHolder.transform.Find("MenuSettings").gameObject;

        if (_menuSettings != null )
            _menuSettings.SetActive(false);

        IsInitialized = true;
    }

    public static void OpenMenu(Menu menu)
    {
        if (!IsInitialized) Init();

        if (_activeMenu != null)
            _activeMenu.SetActive(false);

        switch (menu)
        {
            case Menu.MAIN:
                _menuMain.SetActive(true);
                _activeMenu = _menuMain;
                break;
            case Menu.SETTINGS:
                _menuSettings.SetActive(true);
                _activeMenu = _menuSettings;
                break;
        }
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        OpenMenu(menu);

        callingMenu.SetActive(false);
    }
}
