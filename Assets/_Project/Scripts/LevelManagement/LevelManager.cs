using UnityEngine.SceneManagement;
public class LevelManager
{
    public static void LoadLevel(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
            return;

        SceneManager.LoadScene(sceneName);
    }
}
