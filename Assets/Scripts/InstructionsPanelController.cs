using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InstructionsPanelController : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Assign the CanvasGroup in Inspector
    public float fadeDuration = 0.5f; // Adjust fade speed

    private bool isPanelVisible = false;

    public UnityEngine.UI.Text buttonText;

    void Start()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void ToggleInstructions()
    {
        isPanelVisible = !isPanelVisible;
        StopAllCoroutines(); // Stop any ongoing fade animations
        canvasGroup.interactable = !canvasGroup.interactable;
        canvasGroup.blocksRaycasts = !canvasGroup.interactable;
        StartCoroutine(FadePanel(isPanelVisible ? 1f : 0f));
        if (isPanelVisible)
        {
            buttonText.text = "x";
        }
        else
        {
            buttonText.text = "?";
        }
    }

    public void CloseInstructions()
    {
        if (isPanelVisible)
        {
            isPanelVisible = false;
            StopAllCoroutines();
            StartCoroutine(FadePanel(0f));
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    private IEnumerator FadePanel(float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        canvasGroup.interactable = targetAlpha > 0;
        canvasGroup.blocksRaycasts = targetAlpha > 0;
    }
}
