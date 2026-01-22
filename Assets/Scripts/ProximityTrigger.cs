using UnityEngine;
using UnityEngine.Events;

public class ProximityTrigger : MonoBehaviour
{
    public UnityEvent onEButtonPress;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke();
        if(Input.GetKey(KeyCode.E))
        {
            onEButtonPress.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }



}
