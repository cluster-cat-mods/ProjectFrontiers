using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    [SerializeField] float boostPowerVertical;
    [SerializeField] float boostPowerHorizontal;
    public Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        rb.AddForce(boostPowerHorizontal, boostPowerVertical, 0, ForceMode.Impulse);
    }
}
