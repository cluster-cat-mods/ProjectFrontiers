using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float boostForce;
    [SerializeField] float boostResistance;
    [SerializeField] float boostUpAmount;
    [SerializeField] float boostForwardAmount;
    [SerializeField] float boostClockTime;
    [SerializeField] float boostRegenModifier;
    [SerializeField] float moveForce;
    [SerializeField] float moveResistance;
    [SerializeField] float maxHeight;
    [SerializeField] float airWalkingHeigt;

    private int moveDirection;
    private bool boostBool;
    private float boostTime;
    private float height;
    private float groundDistance;

    private void SetGroundHeigt()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            groundDistance = hit.distance;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetGroundHeigt();
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
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            height = hit.distance - groundDistance;
        }

        if (boostBool == true && boostTime > 0)
        {
            rb.AddForce(new Vector3(boostForwardAmount * moveDirection, boostUpAmount, 0) * (boostForce - boostForce * (height / maxHeight) - boostResistance * rb.linearVelocity.y));
            boostTime -= Time.deltaTime;
        }
        else if (boostBool == false && boostTime < boostClockTime)
        {
            boostTime += Time.deltaTime * boostRegenModifier;
        }

        if (moveDirection != 0 && height < airWalkingHeigt)
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
