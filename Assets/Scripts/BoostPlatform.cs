using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    [SerializeField] Vector3 boostDirection;
    [SerializeField][Min(0)] float boostForce;
    private Rigidbody rb;


    private void OnCollisionEnter(Collision other)
    {
        rb = other.rigidbody;
        rb.linearVelocity = rb.linearVelocity.magnitude * boostDirection;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + boostDirection);
    }
}
