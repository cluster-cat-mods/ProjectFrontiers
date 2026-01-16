using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField][Min(0)] float moveForce;
    [SerializeField][Min(0)] float moveResistance;
    [SerializeField][Min(0)] float airWalkingHeight;

    [Header("Boost Settings")]
    [SerializeField][Min(0)] float boostForce;
    [SerializeField][Range(0, 1)] float boostUpAmount;
    [SerializeField][Range(0, 1)] float boostForwardAmount;
    [SerializeField][Min(0)] float boostResistance;
    [SerializeField][Min(0)] float boostClockTime;
    [SerializeField][Min(0)] float boostRegenModifier;
    [SerializeField][Min(0)] float maxHeight;

    private Rigidbody rb;
    private int moveDirection;
    private bool boostBool;
    private float boostTime;
    private float height;
    private bool groundBool;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            boostBool = true;
        }
        else
        {
            boostBool = false;
        }


        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                moveDirection = 0;
            }
            else
            {
                moveDirection = 1;
            }
        }
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                moveDirection = 0;
            }
            else
            {
                moveDirection = -1;
            }
        }
        else
        {
            moveDirection = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            groundBool = true;
        }
        if (collision.collider.tag == "Platform")
        {
            groundBool = true;
            transform.SetParent(collision.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            groundBool = false;
        }
        if (collision.collider.tag == "Platform")
        {
            groundBool = true;
            transform.SetParent(null);
        }
    }
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            float height = hit.distance;
        }

        if (boostBool == true && boostTime > 0)
        {
            rb.AddForce(new Vector3(boostForwardAmount * moveDirection, boostUpAmount, 0) * (boostForce - boostForce * (height / maxHeight) - boostResistance * rb.linearVelocity.y));
            boostTime -= Time.deltaTime;
        }
        else if (boostBool == false && groundBool && boostTime < boostClockTime)
        {
            boostTime += Time.deltaTime * boostRegenModifier;
        }

        if (moveDirection != 0 && groundBool)
        {
            rb.AddForce((moveForce - moveForce / moveResistance * rb.linearVelocity.x) * transform.forward * moveDirection);
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 5f);
        }else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 5f);
        }

        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(ray.origin, 0.2f);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(hit.point, 0.1f);
    }
}
