using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text gameOverScore; 

    private int score;
    private Text scoreText;

    private void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        if (score < 10)
        {
            scoreText.text = "0" + score;
        }
        else
        {
            scoreText.text = "" + score;
        }

        gameOverScore.text = "Points:\n" + score;
    }

    // Adds points to the Score
    public void UpdateScore(int points)
    {
        score += points;
    }
}
