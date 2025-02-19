using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the camera around its Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
