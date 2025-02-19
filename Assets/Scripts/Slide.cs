using UnityEngine;
using System.Collections;

public class SlideUI : MonoBehaviour
{
    public RectTransform target; // Assign the UI panel
    public float duration = 1f;  // Transition time in seconds

    public void SlideLeft()
    {
        StartCoroutine(SlideMinX(1f, 0f)); // Move min X from 1 to 0
    }

    public void SlideRight()
    {
        StartCoroutine(SlideMaxX(1f, 0f)); // Move max X from 1 to 0
    }

    private IEnumerator SlideMinX(float start, float end)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newValue = Mathf.Lerp(start, end, elapsedTime / duration);
            target.anchorMin = new Vector2(newValue, target.anchorMin.y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.anchorMin = new Vector2(end, target.anchorMin.y); // Ensure final position
    }

    private IEnumerator SlideMaxX(float start, float end)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newValue = Mathf.Lerp(start, end, elapsedTime / duration);
            target.anchorMax = new Vector2(newValue, target.anchorMax.y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.anchorMax = new Vector2(end, target.anchorMax.y); // Ensure final position

        
        target.anchorMin = new Vector2(1, target.anchorMin.y);
        target.anchorMax = new Vector2(1, target.anchorMax.y); 
    }
}
