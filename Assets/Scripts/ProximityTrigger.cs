using UnityEngine;
using UnityEngine.Events;

public class ProximityTrigger : MonoBehaviour
{
    public GameObject UITextObject;
    public UnityEvent EButtonPress;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PopUp UI");
            UITextObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
            if(Input.GetKey(KeyCode.E))
            {
                EButtonPress.Invoke();
            }
    }

    private void OnTriggerExit(Collider other)
    { 
        if(other.tag == "Player")
        {
            Debug.Log("UI go away");
            UITextObject.SetActive(false);
        }
    }
}
