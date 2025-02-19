using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public FloatingTextUI penaltyText; // Assign in Inspector
    public GameTimer timerManager; // Reference to your timer script
    public float penaltyCooldown = 2f; // Time before the player can be penalized again

    private float lastPenaltyTime = -Mathf.Infinity; // Tracks last penalty time

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if enough time has passed since the last penalty
            if (Time.time >= lastPenaltyTime + penaltyCooldown)
            {
                timerManager.AdjustTime(-5); // Deduct 5 seconds
                penaltyText.ShowText(); // Show "-5 SECONDS!" text
                lastPenaltyTime = Time.time; // Update penalty timer
            }
        }
    }
}
