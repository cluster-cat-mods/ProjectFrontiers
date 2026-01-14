using System.IO.Compression;
using UnityEngine;

public class CamerpointGiizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(transform.position, 0.125f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}

