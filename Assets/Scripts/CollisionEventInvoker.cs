using UnityEngine;
using UnityEngine.Events;

public class CollisionEventInvoker : MonoBehaviour
{
    public UnityEvent OnCollisionEnterEvent;
    public UnityEvent OnCollisionStayEvent;
    public UnityEvent OnCollisionExitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEnterEvent.Invoke();
    }

    private void OnCollisionStay(Collision collision)
    {
        OnCollisionStayEvent.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        OnCollisionExitEvent.Invoke();
    }
}
