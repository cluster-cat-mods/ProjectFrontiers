using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIFunctions : MonoBehaviour
{
    [SerializeField] private UnityEvent UIEvent;
    [SerializeField] float sceneLoadWaitDuration;

    private string sceneName;
    private void SceneLoader()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(string sceneNameP)
    {
        sceneName = sceneNameP;
        Invoke("SceneLoader", sceneLoadWaitDuration);
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

