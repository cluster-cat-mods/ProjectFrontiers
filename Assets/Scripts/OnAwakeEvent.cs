using UnityEngine;
using UnityEngine.Events;

public class OnAwakeEvent : MonoBehaviour
{
    public UnityEvent onAwakeEvent;

    private void Awake()
    {
        onAwakeEvent.Invoke();
    }
}
