using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 100; // Points awarded when the coin is collected
    private bool isCollected = false;

    void Update()
    {
        if (!isCollected)
        {
            // Make the coin spin around the Y-axis (using deltaTime to make it frame-rate independent)
            transform.Rotate(0, 100f * Time.deltaTime, 0); // 100f is the rotation speed
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the coin
        if (other.CompareTag("Player") && !isCollected)
        {
            CollectCoin();
        }
    }

    void CollectCoin()
    {
        // Add points to the score
        ScoreManager.Instance.AddPoints(points);

        // Set the coin to be collected and disable it (it will disappear)
        isCollected = true;
        gameObject.SetActive(false); // Coin disappears after collection
    }
}
