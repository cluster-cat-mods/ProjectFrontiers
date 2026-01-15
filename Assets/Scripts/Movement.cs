using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float boostForce;
    [SerializeField] float boostResistance;
    [SerializeField] float moveForce;
    [SerializeField] float moveResistance;
    [SerializeField] float maxHeight;

    private int moveDirection;
    private bool boostBool;

    private float height;

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
    private void FixedUpdate()
    {
        if (boostBool == true)
        {
            Ray ray = new Ray(transform.position, transform.up *  -1);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                height = hit.distance;
                rb.AddForce(new Vector3(0, boostForce - boostForce * (height / maxHeight) - boostResistance * rb.linearVelocity.y, 0));
            }
        }

        if (moveDirection != 0)
        {
            rb.AddForce((moveForce - moveForce / moveResistance * rb.linearVelocity.x) * transform.forward * moveDirection);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(transform.position, 0.25f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.up * -1);
    }
}
