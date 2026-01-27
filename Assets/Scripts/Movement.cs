using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

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

    [Header("Audio Settings")]
    [SerializeField] private AudioSource footstepSource;
    [SerializeField] private AudioSource boostSource;

    [SerializeField] List<AudioClip> footstepAudioClips;
    [SerializeField][Min(0)] private float stepDist;
    [SerializeField] private AudioClip boostAudioClip;

    private Rigidbody rb;
    private Animator animator;

    private int moveDirection;
    private bool boostBool;
    private float boostTime;
    private float height;
    private bool groundBool;

    private Vector3 prevPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        boostSource.clip = boostAudioClip;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            boostBool = true;
            animator.SetBool("isBoosting", true);
        }
        else
        {
            boostBool = false;
            animator.SetBool("isBoosting", false);
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
                transform.rotation = Quaternion.Euler(0, -90, 0);

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
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        else
        {
            moveDirection = 0;
        }

        if (groundBool && Vector3.Distance(transform.position, prevPos) > stepDist)
        {
            footstepSource.PlayOneShot(footstepAudioClips[Random.Range(0, footstepAudioClips.Count - 1)]);
            prevPos = transform.position;
        }

        if (boostBool == true && boostTime > 0)
        {
            if (!boostSource.loop)
            {
                boostSource.loop = true;
            }
            if (!boostSource.isPlaying)
            {
                boostSource.Play();
            }
        }
        else 
        {
            if (boostSource.isPlaying)
            {
                boostSource.Stop();
            }
            if (boostSource.loop)
            {
                boostSource.loop = false;
            }
        }

    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            height = hit.distance -1;
        }

        if (height < airWalkingHeight)
        {
            groundBool = true;
        }
        else
        {
            groundBool = false;
        }

        if (hit.collider.tag == "Platform")
        {
            transform.SetParent(hit.collider.transform);
        }
        else
        {
            transform.SetParent(null);
        }

        if (boostBool == true && boostTime > 0)
        {
            float bForceUp = boostForce - boostForce * (height / maxHeight) - boostResistance * rb.linearVelocity.y;
            float bForceForward = boostForce - boostForce - boostResistance * rb.linearVelocity.y;
            if (bForceForward < 0)
            {
                bForceForward = 0;
            }
            if (bForceUp < 0)
            {
                bForceUp = 0;
            }

            rb.AddForce(new Vector3(boostForwardAmount * -moveDirection * bForceForward, boostUpAmount * bForceUp, 0));
            boostTime -= Time.deltaTime;
        }
        else if (boostBool == false && groundBool && boostTime < boostClockTime)
        {
            boostTime += Time.deltaTime * boostRegenModifier;
        }

        if (moveDirection != 0 && groundBool)
        {
            float mForce = moveForce - moveForce / moveResistance * rb.linearVelocity.x;
            if (mForce < 0)
            {
                mForce = 0;
            }
            rb.AddForce(transform.forward * mForce);
        }
        animator.SetFloat("xVel", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVel", rb.linearVelocity.y);
        animator.SetFloat("height", height);
    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (groundBool)
            {
                Gizmos.color = Color.blue;
            }
            else
            {
                Gizmos.color = Color.green;
            }
        }
        else 
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 5f);

        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(ray.origin, 0.2f);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(hit.point, 0.1f);
    }
}
