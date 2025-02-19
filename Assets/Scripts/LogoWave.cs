using UnityEngine;
using UnityEngine.UI;

public class WaveEffectUI : MonoBehaviour
{
    public float rotationSpeed = 2f; // Speed of rotation oscillation
    public float rotationAmount = 15f; // Max rotation in degrees

    public float scaleSpeed = 2f; // Speed of scaling oscillation
    public float scaleAmount = 0.2f; // Max scale change

    private RectTransform rectTransform;
    private Vector3 initialScale;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialScale = rectTransform.localScale;
    }

    void Update()
    {
        // Rotation in a sine wave
        float rotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAmount;
        rectTransform.localRotation = Quaternion.Euler(0, 0, rotation);

        // Scaling in a sine wave
        float scaleFactor = 1 + Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
        rectTransform.localScale = initialScale * scaleFactor;
    }
}
