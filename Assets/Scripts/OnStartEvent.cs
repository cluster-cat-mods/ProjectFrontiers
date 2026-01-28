using UnityEngine;
using UnityEngine.Events;

public class OnStartEvent : MonoBehaviour
{
    public UnityEvent onStartEvent;

    void Start()
    {
        onStartEvent.Invoke();
    }
}
