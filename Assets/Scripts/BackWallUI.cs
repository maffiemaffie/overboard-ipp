using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class BackWallUI : MonoBehaviour
{
    public GameObject playersPanel;
    public GameObject timer;
    public GameObject score;
    public GameObject player1;
    public GameObject player2;
    public GameObject speechBubble;
    public GameObject speechBubblePanel;
    private List<OverboardPlayer> players = new List<OverboardPlayer>();

    private OverboardPlayer example = new OverboardPlayer("colby", 0, 69);

    public struct OverboardPlayer
    {
        public string name;
        public int score;
        public int metagameScore;
        public OverboardPlayer(string name, int score, int metagameScore)
        {
            this.name = name;
            this.score = score;
            this.metagameScore = metagameScore;
        }
    }

    public void SetTimer(int time)
    {
        timer.GetComponent<TextMeshProUGUI>().text = "0:" + time.ToString();
    }

    public void SetScore(int newScore)
    {
        score.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
    }

    public void AddPlayer(OverboardPlayer player)
    {
        players.Add(player);

        if (players.Count == 1)
        {
            GameObject newPlayer = Instantiate(player1, playersPanel.transform);
            newPlayer.GetComponent<PlayerUI>().PlayerNumber = players.Count;
            newPlayer.GetComponent<PlayerUI>().Player = player;
        }
        else if (players.Count == 2)
        {
            GameObject newPlayer = Instantiate(player2, playersPanel.transform);
            newPlayer.GetComponent<PlayerUI>().PlayerNumber = players.Count;
            newPlayer.GetComponent<PlayerUI>().Player = player;
        }
    }

    public void Squawk(string heading, string body)
    {
        foreach (Transform child in speechBubblePanel.transform)
        {
            Destroy(child.gameObject);
        }

        GameObject newBubble = Instantiate(speechBubble, speechBubblePanel.transform);
        newBubble.GetComponent<SpeechBubble>().Heading = heading;
        newBubble.GetComponent<SpeechBubble>().Body = body;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score.GetComponent<TextMeshProUGUI>().text = "0";
        AddPlayer(example);
        AddPlayer(example);
        Squawk("hi elia", "this is a test");
    }
}
