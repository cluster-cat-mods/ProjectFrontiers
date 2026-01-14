using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject CheckPoint;
    Vector3 CheckPointPos;

    private void Start()
    {
        CheckPoint = GameObject.Find("CheckPoint");
        CheckPointPos = CheckPoint.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            transform.position = CheckPointPos;
        }
    }
}
