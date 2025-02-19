using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float lookSpeedX = 2f; // Sensitivity for looking around horizontally
    public float lookSpeedY = 2f; // Sensitivity for looking around vertically
    private Rigidbody rb;
    private bool isGrounded = true;
    public SlideUI slidePanel;

    private Camera playerCamera;
    private float rotationX = 0f;
    private float rotationY = 0f;

    // Reference to the CameraController (drag the CameraController GameObject here in the inspector)
    public CameraController cameraController;

    // Camera offset from player position
    public Vector3 cameraOffset = new Vector3(0f, 1.0f, 0f); // Adjust as needed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main; // Get the camera
        slidePanel.SlideRight();
    }

    void Update()
    {
        // Check the current camera view from the CameraController's enum
        CameraController.CameraView currentView = cameraController.GetCurrentCameraView();

        // Handle rotation based on mouse movement only if in first-person mode
        if (currentView == CameraController.CameraView.FirstPerson)
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;


            // Rotate the camera vertically (around X axis) with mouseY (up/down)
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Prevent over-rotation
            rotationY += mouseX;
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }

        // Handle movement based on WASD input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create movement vector relative to the player rotation
        if (moveX != 0 || moveZ != 0)
        {
            Vector3 movement = (transform.right * moveX + transform.forward * moveZ).normalized * moveSpeed;
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0); // Instantly stop movement
        }

        // Handle jumping when grounded
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            isGrounded = false;
        }

        // Update the camera position to follow the player
        if (currentView == CameraController.CameraView.FirstPerson)
        {
            // Position the camera at a fixed offset relative to the player's position
            playerCamera.transform.position = transform.position + cameraOffset;
        }
        else
        {
            // For other views, you can adjust the camera's position or logic if necessary
        }

        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation.y = playerCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(newRotation);
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
