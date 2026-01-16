using UnityEngine;
using UnityEngine.Events;


public class PauseChecker : MonoBehaviour
{
    public UnityEvent pauseEvent;
    public UnityEvent UnpauseEvent;
    private bool isPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (!isPaused)
            {
                pauseEvent.Invoke();
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                UnpauseEvent.Invoke();
                Time.timeScale = 1f;
                isPaused = false;
        }
        }
    }
}
