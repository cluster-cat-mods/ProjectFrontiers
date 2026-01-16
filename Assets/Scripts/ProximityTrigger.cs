using UnityEngine;
using UnityEngine.Events;

public class ProximityTrigger : MonoBehaviour
{
    public GameObject EProximityTrigger;
    public UnityEvent EButtonPress;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PopUp UI");
            EProximityTrigger.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
            if(Input.GetKeyDown(KeyCode.E))
            {
                EButtonPress.Invoke();
            }
    }

    private void OnTriggerExit(Collider other)
    { 
        if(other.tag == "Player")
        {
            Debug.Log("UI go away");
            EProximityTrigger.SetActive(false);
        }
    }
}
