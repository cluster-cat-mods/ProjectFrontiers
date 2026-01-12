using UnityEngine;
using Unity.Collections;

public class MouseFollow : MonoBehaviour
{
    void Update()
    {
        transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
