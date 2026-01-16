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

    public void PauseGame()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void ToggleGameObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}
