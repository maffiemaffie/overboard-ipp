using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float lookSpeedX = 2f; // Sensitivity for looking around horizontally
    public float lookSpeedY = 2f; // Sensitivity for looking around vertically
    private Rigidbody rb;
    private bool isGrounded = true;

    private Camera playerCamera;
    private float rotationX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main; // Get the camera attached to the player
    }

    void Update()
    {
        // Handle rotation based on mouse movement
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;

        // Rotate the player horizontally (around Y axis)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically (around X axis)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Prevent over-rotation
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Handle movement based on WASD input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * moveX + transform.forward * moveZ).normalized * moveSpeed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // Handle jumping when grounded
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player has collided with the ground to reset isGrounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
