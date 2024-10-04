using UnityEngine;
using UnityEngine.SceneManagement;  // Necessary to access scene management

public class SceneLoader : MonoBehaviour
{
    // Public variables for setting scene details in the Unity Editor
    public string sceneName;  // For scene name
    public int sceneIndex;    // For scene index

    // This function loads a scene by the name set in the Editor
    public void LoadSceneByName()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set.");
        }
    }

    // This function loads a scene by the index set in the Editor
    public void LoadSceneByIndex()
    {
        if (sceneIndex >= 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Scene index is not valid.");
        }
    }
}