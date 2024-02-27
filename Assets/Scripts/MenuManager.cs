using UnityEditor;
using UnityEngine;

public enum Menu
{
    MAIN,
    SETTINGS,
    NONE
}

public enum SettingsGroup
{
    LANGUAGE,
    AUDIO,
    VIDEO,
    CONTROLS
}

public static class MenuManager
{
    public static bool IsInitialized = false;
    public static GameObject mainMenu, settingsMenu, languageGroup, audioGroup, videoGroup, controlsGroup;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;

        languageGroup = canvas.transform.Find("Language").gameObject;
        audioGroup = canvas.transform.Find("Audio").gameObject;
        videoGroup = canvas.transform.Find("Video").gameObject;
        controlsGroup = canvas.transform.Find("Controls").gameObject;

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
                mainMenu.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }

    public static void OpenSettingsGroup(SettingsGroup group, GameObject callingGroup)
    {
        if (!IsInitialized) Init();

        switch (group)
        {
            case SettingsGroup.LANGUAGE:
                languageGroup.SetActive(true);
                break;
            case SettingsGroup.AUDIO:
                audioGroup.SetActive(true);
                break;
            case SettingsGroup.VIDEO:
                videoGroup.SetActive(true);
                break;
            case SettingsGroup.CONTROLS:
                controlsGroup.SetActive(true);
                break;
        }

        callingGroup.SetActive(false);
    }
}
