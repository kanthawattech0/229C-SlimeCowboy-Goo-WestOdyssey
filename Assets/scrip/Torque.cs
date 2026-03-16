using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    public float torquePower = 50f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(Vector3.up * torquePower);
    }
}
