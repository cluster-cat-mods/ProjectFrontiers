using UnityEngine;
using UnityEngine.Events;

public class CollisionEventInvoker : MonoBehaviour
{
    public UnityEvent OnCollisionEnterEvent;
    public UnityEvent OnCollisionStayEvent;
    public UnityEvent OnCollisionExitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if(!enabled) return;
        OnCollisionEnterEvent.Invoke();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!enabled) return;
        OnCollisionStayEvent.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!enabled) return;
        OnCollisionExitEvent.Invoke();
    }
}
