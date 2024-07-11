using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void SwitchScene(string newScene)
    {
        StartCoroutine(SwitchScenesCoroutine(newScene));
    }

    private IEnumerator SwitchScenesCoroutine(string newScene)
    {
        string currentScene = SceneManager.GetActiveScene().name;

        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(currentScene);
        yield return unloadOperation;

        SceneManager.LoadScene(newScene, LoadSceneMode.Additive);

        while (!SceneManager.GetSceneByName(newScene).isLoaded)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newScene));
    }

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
