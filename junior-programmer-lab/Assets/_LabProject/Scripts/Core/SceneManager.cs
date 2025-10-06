using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadCurrentScene()
    {
        LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
