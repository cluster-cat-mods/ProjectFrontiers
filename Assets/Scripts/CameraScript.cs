using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private GameObject startPoint;

    private bool zoomBool = false;
    private Camera cam;
    private CinemachineCamera vcam;
    private Transform followTransform;
    private Plane cursorPlane;

    public void DoCameraZoom(GameObject objectP)
    {
        zoomBool = !zoomBool;
        vcam.ForceCameraPosition(objectP.transform.GetChild(0).position, objectP.transform.GetChild(0).rotation);
        if (objectP != startPoint)
        {
            vcam.LookAt = objectP.transform;
        }
        else
        {
            vcam.LookAt = followTransform;
        }
    }

    private void Awake()
    {
        cam = GetComponent<Camera>();
        vcam = FindFirstObjectByType<CinemachineCamera>();
        if (vcam == null)
        {
            Debug.LogError("No vcam found");
        }

        GameObject target = new GameObject("CinemachineCursorTarget");
        followTransform = target.transform;
        vcam.LookAt = followTransform;
    }

    private void Update()
    {
        //looking
        cursorPlane = new Plane(cam.transform.forward, cam.transform.position + cam.transform.forward * distance);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (!zoomBool && cursorPlane.Raycast(ray, out float enter))
        {
            followTransform.position = ray.GetPoint(enter);
        }


        //actions
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Clicked: " + hit.collider.name);
                if (!zoomBool && hit.collider.tag == "zoomObject")
                {
                    DoCameraZoom(hit.collider.GameObject());
                }
            }
        }
        if (Input.GetKey(KeyCode.Escape) && zoomBool)
        {
            DoCameraZoom(startPoint);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(followTransform.position, 0.5f);
    }

}


