using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour { 

    private int score = 0;
    private int i = 100;

    public bool scoreIsActive = true;
    public int finalScore;
    public Text scoreDisplay;
    public Text finalScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score:" + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIsActive == true)
        {
            if (i == 0)
            {
                score++;
                scoreDisplay.text = "Score:" + score.ToString();
                i = 100;
            }
            else
            {
                i--;
            }
        }
        else
        {
            finalScore = score;
            finalScreen.text = "Score:" + finalScore + "\nGame Over! \nhit R to restart";
        }
    } 
}
