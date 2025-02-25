using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Handle movement based on WASD input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create movement vector relative to the player rotation
        if (moveX != 0 || moveZ != 0)
        {
            Vector3 movement = (transform.right * moveX + transform.forward * moveZ).normalized * moveSpeed;
            // rb.linearVelocity = new Vector3(movement.x, 0, movement.z);
            transform.position += movement * Time.deltaTime;
        }
    }

    private void GoToPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, 0, position.y);
    }
}
