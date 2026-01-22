using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    [SerializeField] Vector3 boostDirection;
    [SerializeField][Min(0)] float boostForce;
    [SerializeField] private AudioClip audioClip;
    
    private AudioSource audioSource;
    private Rigidbody rb;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.rigidbody;
            rb.AddForce(boostForce * boostDirection, ForceMode.Impulse);
            audioSource.Play();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + boostDirection);
    }
}
