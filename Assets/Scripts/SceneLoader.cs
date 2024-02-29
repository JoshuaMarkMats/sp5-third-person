using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(string sceneName)
    {
        MenuManager.IsInitialized = false;
        SceneManager.LoadScene(sceneName);
    }
}
