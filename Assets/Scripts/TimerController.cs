using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60.99f;
    public UnityEngine.UI.Text timerText;
    public CanvasGroup inGameUI;
    public CanvasGroup gameOverUI;
    public float fadeDuration = 1f;
    public PlayerController player;
    public FlotsamManager spawner;
    public ScoreManager score;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;
        timeRemaining = Mathf.Max(timeRemaining, 0); // Ensure time doesn't go below 0

        // Update the timer UI
        timerText.text = "TIME: " + Mathf.FloorToInt(timeRemaining);

        // If time reaches zero, trigger game over
        if (timeRemaining <= 0)
        {
            StartCoroutine(HandleGameOver());
        }
    }

    IEnumerator HandleGameOver()
    {
        isGameOver = true;

        // Instantly hide in-game UI
        inGameUI.alpha = 0;
        inGameUI.interactable = false;
        inGameUI.blocksRaycasts = false;

        player.enabled = false;
        spawner.Stop();
        score.Stop();

        // Fade in game-over UI
        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            gameOverUI.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameOverUI.alpha = 1;
        gameOverUI.interactable = true;
        gameOverUI.blocksRaycasts = true;
    }

    public void AdjustTime(float amount)
    {
        timeRemaining += amount;
        if (timeRemaining < 0) timeRemaining = 0; // Prevent negative time
    }

}
