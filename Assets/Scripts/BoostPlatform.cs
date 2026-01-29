using UnityEngine;
using UnityEngine.Events;

public class BoostPlatform : MonoBehaviour
{
    [SerializeField] Vector3 boostDirection;
    [SerializeField][Min(0)] float boostForce;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;
    
    private AudioSource audioSource;
    private Rigidbody rb;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.attachedRigidbody;
            rb.AddForce(boostForce * boostDirection, ForceMode.Impulse);
            audioSource.Play();
            animator.Play(animationName);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + boostDirection);
    }
}
