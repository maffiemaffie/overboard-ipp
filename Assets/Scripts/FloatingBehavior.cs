using System;
using UnityEngine;

public class FloatingBehavior : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of slow rotation

    private Vector3 startPosition;

    void Start()
    {
        rotationSpeed += UnityEngine.Random.Range(0, 5);

        if (UnityEngine.Random.Range(0, 1) == 1)
        {
            rotationSpeed *= -1;
        } 
    }

    void Update()
    {
        // Rotate slightly
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
