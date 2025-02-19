using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;  // Reference to the camera
    public Transform player;     // Reference to the player object
    public Transform topDownPosition;  // Position for top-down view
    public Transform isometricPosition;  // Position for isometric view

    private Vector3 firstPersonOffset; // Offset for the first-person camera

    public enum CameraView { FirstPerson, TopDown, Isometric }
    private CameraView currentView;

    private void Start()
    {
        // Set the offset for the first-person camera (adjust based on the player's height)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        firstPersonOffset = new Vector3(0, 1.0f, 0); // Adjust this to suit your player height
        currentView = CameraView.FirstPerson;  // Start in first-person view
        SetCameraView();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click to lock the cursor
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Press ESC to unlock
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Switch between camera views with hotkeys
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 key for first-person view
        {
            Camera.main.orthographic = false;
            currentView = CameraView.FirstPerson;
            SetCameraView();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 key for top-down view
        {
            Camera.main.orthographicSize = 11.4f;
            Camera.main.orthographic = true;
            currentView = CameraView.TopDown;
            SetCameraView();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // 3 key for isometric view
        {
            Camera.main.orthographic = false;
            currentView = CameraView.Isometric;
            SetCameraView();
        }

        // For first-person view, follow the player position at all times
        if (currentView == CameraView.FirstPerson)
        {
            playerCamera.transform.position = player.position + firstPersonOffset;
            playerCamera.transform.rotation = player.rotation;
        }
    }

    private void SetCameraView()
    {
        // Set camera's position and rotation based on the selected view
        switch (currentView)
        {
            case CameraView.FirstPerson:
                // Camera position and rotation is handled in Update for first-person
                break;
            case CameraView.TopDown:
                playerCamera.transform.position = topDownPosition.position;
                playerCamera.transform.rotation = topDownPosition.rotation;
                break;
            case CameraView.Isometric:
                playerCamera.transform.position = isometricPosition.position;
                playerCamera.transform.rotation = isometricPosition.rotation;
                break;
        }
    }

    // Getter method for the current camera view
    public CameraView GetCurrentCameraView()
    {
        return currentView;
    }
}
