using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(string sceneName)
    {
        MenuManager.IsInitialized = false;
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadScene(int sceneIndex)
    {
        MenuManager.IsInitialized = false;
        SceneManager.LoadScene(sceneIndex);
    }
}
