using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    [SerializeField] float JumpForce;
    [SerializeField] float MovementSpeed;
    [SerializeField] float MaxSpeed;
    private bool JumpRequested = false;
    private int JumpAmount = 2;
    private bool isGrounded;

    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpRequested = true;
        }
        if (isGrounded == true)
        {
            JumpAmount = 1;
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(body.position, Vector3.down, 1.1f);
        Debug.DrawRay(body.position, Vector3.down * 1.05f, Color.red, 0, false);

        if (JumpRequested == true && JumpAmount > 0)
        {
            body.AddForce(0, JumpForce, 0, ForceMode.VelocityChange);
            JumpAmount--;
            JumpRequested = false;
        }

        if ((Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) && body.linearVelocity.magnitude < MaxSpeed)
        {
            body.AddForce(Vector3.right * MovementSpeed);
            Debug.Log(body.linearVelocity.magnitude);
        }
        if ((Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) && body.linearVelocity.magnitude < MaxSpeed)
        {
            body.AddForce(Vector3.left * MovementSpeed);
            Debug.Log(body.linearVelocity.magnitude);
        }

    }

}
