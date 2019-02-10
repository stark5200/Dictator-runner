using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour { 

    private int score = 0;
    public Text scoreDisplay;
    void OnTriggerEnter2D(Collider2D obstacle)
    {
        if (obstacle.CompareTag("Obstacle")) {
            score++;
            scoreDisplay.text = "Score:" + score.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score:" + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
