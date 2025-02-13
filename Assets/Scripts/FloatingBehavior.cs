using System;
using UnityEngine;

public class FloatingBehavior : MonoBehaviour
{
    public float floatStrength = 0.5f; // How high/low the platform moves
    public float floatSpeed = 2f; // Speed of floating motion
    public float rotationSpeed = 10f; // Speed of slow rotation

    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        randomOffset = UnityEngine.Random.Range(0f, 2f * Mathf.PI); // Add variation in movement
    }

    void Update()
    {
        // Bob up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed + randomOffset) * floatStrength;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Rotate slightly
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
