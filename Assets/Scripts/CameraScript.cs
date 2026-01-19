using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject startPoint;

    private bool zoomBool = false;
    private Camera cam;
    private CinemachineCamera vcam;
    private CinemachineRotationComposer rotComp;
    private Transform followTransform;

    public void DoCameraZoom(GameObject objectP)
    {
        zoomBool = !zoomBool;
        if (objectP != startPoint)
        {
            rotComp.enabled = false;
            vcam.transform.position = objectP.transform.GetChild(0).transform.position;
            vcam.transform.rotation = objectP.transform.GetChild(0).transform.rotation;
        }
        else
        {
            rotComp.enabled = true;
            vcam.transform.position = objectP.transform.position;
        }
    }

    private void Awake()
    {
        cam = GetComponent<Camera>();
        vcam = FindFirstObjectByType<CinemachineCamera>();
        rotComp = vcam.GetComponent<CinemachineRotationComposer>();
        if (vcam == null)
        {
            Debug.LogError("No vcam found");
        }

        GameObject target = new GameObject("CinemachineCursorTarget");
        target.transform.position = cam.transform.position + new Vector3(0, 0, 5);
        followTransform = target.transform;
        vcam.LookAt = followTransform;
    }

    private void Update()
    {
        //looking
        Vector3 mousPos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousPos);
        Physics.Raycast(ray, out RaycastHit hit);

        
        if (Input.GetMouseButtonDown(0) && !zoomBool)
        {
            if (hit.collider != null && hit.collider.tag == "zoomObject")
            {
                DoCameraZoom(hit.collider.GameObject());
            }
            else
            {
                followTransform.position = hit.point;
            }
        }

        if (Input.GetKey(KeyCode.Escape) && zoomBool)
        {
            DoCameraZoom(startPoint);
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(followTransform.position, 0.5f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(ray.origin, hit.point);
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(ray.origin, 0.25f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hit.point, 0.25f);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(Input.mousePosition + new Vector3(Screen.width / 2, Screen.height / 2, 0), 0.25f);
    }

}


