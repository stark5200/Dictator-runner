using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public GameObject obstacle;

    private int score = 0;
    private int i = 100;
    public int highscore = 0;

    public bool scoreIsActive = true;
    public int finalScore;
    public Text scoreDisplay;
    public Text highscoreDisplay;
    public Text finalScreen;

    private Transform scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score:" + score.ToString();
        LoadScore();
        highscoreDisplay.text = "Highcore:" + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle detected");
            if (scoreIsActive)
            {
                score++;
                scoreDisplay.text = "Score:" + score.ToString();
                if (score >= highscore)
                {
                    highscore = score;
                    highscoreDisplay.text = "Highscore:" + highscore.ToString();
                    SaveScore();
                }
                Debug.Log("increased score");
            }
            else
            {
                finalScore = score;
                finalScreen.text = "Score:" + finalScore + "\nGame Over! \nhit R to restart";
            }
        }
    }

    public void SaveScore()
    {
        SaveSystem.SaveHighscore(this);
    }

    public void LoadScore()
    {
        ScoreData scoreData = SaveSystem.LoadHighscore();

        highscore = scoreData.highscore;
    }
}
