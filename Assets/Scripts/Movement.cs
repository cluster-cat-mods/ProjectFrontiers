using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    [SerializeField] float JumpForce;
    private bool JumpRequested = false;
    private int JumpTimes = 2;
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
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(body.position, Vector3.down, 1.1f);
        Debug.DrawRay(body.position, Vector3.down * 1.1f, Color.red, 0, false);

        if (JumpRequested == true && isGrounded == true)
        {
            body.AddForce(0, JumpForce, 0);
            JumpTimes--;
            JumpRequested = false;
        }

    }

}
