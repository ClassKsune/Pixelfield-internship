using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private static SceneSwitcher instance;

    private void Awake()
    {
        // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// Loads a scene by its name.
    /// Usable for loading scene in non-index order
    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("SceneSwitcher: Scene name is empty!");
        }
    }

    /// Reloads the current scene.
    /// Used for relofing physics for physics_scene
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// Loads the next scene in Build Settings.
    /// Usable for levels
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("SceneSwitcher: No next scene available.");
        }
    }

    /// Loads the previous scene in Build Settings.
    /// Can be used to going back to menu
    public void LoadPreviousScene()
    {
        int prevSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (prevSceneIndex >= 0)
        {
            SceneManager.LoadScene(prevSceneIndex);
        }
        else
        {
            Debug.LogWarning("SceneSwitcher: No previous scene available.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("SceneSwitcher: Quitting game...");
        Application.Quit();
    }
}

