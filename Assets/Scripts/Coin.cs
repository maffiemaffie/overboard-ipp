using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 100; // Points awarded when the coin is collected
    private bool isCollected = false;
    private bool isVisible = false;
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        // Start the coin as invisible and with collision disabled
        gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isCollected && !isVisible && transform.position.y > 0)
        {
            // Play the sprite animation
            animator.Play("CoinAppear"); // Assuming "CoinAppear" is the name of the animation
            isVisible = true;
        }

        if (isVisible && !isCollected)
        {
            // Make the coin spin around the Y-axis (using deltaTime to make it frame-rate independent)
            transform.Rotate(100f * Time.deltaTime, 0, 0); // 100f is the rotation speed
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the coin
        if ((other.CompareTag("LeftFoot") || other.CompareTag("RightFoot")) && !isCollected)
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

    // This method should be called at the end of the "CoinAppear" animation
    public void OnAnimationEnd()
    {
        gameObject.SetActive(true);
        GetComponent<Collider>().enabled = true;
    }
}
