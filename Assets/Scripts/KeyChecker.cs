using UnityEngine;
using UnityEngine.Events;


public class keychecker : MonoBehaviour
{
    public UnityEvent KeyEvent;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed");
            KeyEvent.Invoke();
        }
    }
}
