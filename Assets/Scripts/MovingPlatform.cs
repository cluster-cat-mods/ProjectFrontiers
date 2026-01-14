using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float phase;
    [SerializeField] float obstacleSpeed;
    [SerializeField] bool Horizontal = false;
    [SerializeField] bool Vertical = false;
    Vector3 startPos;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Horizontal == true)
        {
            HorizontalMove();
        }
        if (Vertical == true)
        {
            VerticalMove();
        }
    }

    private void HorizontalMove()
    {
        Vector3 positionoffset = new Vector3(amplitude * Mathf.Sin((Time.time - phase) * obstacleSpeed), 0, 0);
        transform.position = startPos + positionoffset;
    }

    private void VerticalMove()
    {
        Vector3 positionoffset = new Vector3(0, amplitude * Mathf.Sin((Time.time - phase) * obstacleSpeed), 0);
        transform.position = startPos + positionoffset;
    }
}
