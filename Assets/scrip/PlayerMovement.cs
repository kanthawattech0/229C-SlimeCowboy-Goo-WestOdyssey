using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveX = 0;
        float moveZ = 0;

        if (Input.GetKey(KeyCode.A))
            moveX = -1;

        if (Input.GetKey(KeyCode.D))
            moveX = 1;

        if (Input.GetKey(KeyCode.W))
            moveZ = 1;

        if (Input.GetKey(KeyCode.S))
            moveZ = -1;

        Vector3 movement = new Vector3(moveX * speed, rb.velocity.y, moveZ * speed);
        rb.velocity = movement;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}