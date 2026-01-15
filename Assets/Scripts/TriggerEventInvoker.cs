using UnityEngine;
using UnityEngine.Events;

public class TriggerEventInvoker : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerStayEvent;
    public UnityEvent OnTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(!enabled) return;
        OnTriggerEnterEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!enabled) return;
        OnTriggerStayEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!enabled) return;
        OnTriggerExitEvent.Invoke();
    }
}
