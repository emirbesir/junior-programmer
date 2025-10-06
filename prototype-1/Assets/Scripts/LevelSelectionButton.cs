using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionButton : MonoBehaviour
{
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
