using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEngine.UI.Text scoreText;
    public GameObject timerText;

public GameObject gameOverPanel;

    private int score = 0;
    private float timeLeft = 60f;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);

        if (timeLeft <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void ReduceTime(float amount)
    {
        timeLeft -= amount;
        if (timeLeft < 0) timeLeft = 0;
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
}
