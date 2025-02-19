using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

public class WarningBlink : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    public float blinkInterval = 0.5f;

    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            image.enabled = !image.enabled; // Toggle visibility
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
