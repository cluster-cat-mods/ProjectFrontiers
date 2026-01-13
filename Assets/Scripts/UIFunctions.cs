using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    public UnityEvent UIEvent;
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EventEvoker()
    {
        UIEvent.Invoke();
    }
}
