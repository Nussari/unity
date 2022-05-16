using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int highScore;
    private int scoreCounter;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore"); //loada met
        scoreCounter = PlayerPrefs.GetInt("score"); //loada stig
        scoreText.text = "Stig: " + scoreCounter.ToString();

        if(highScore < scoreCounter)
        {
            highScoreText.text = "Gamla metið: " + highScore.ToString(); //skrifa mismunandi eftir hvort metið var slegið
            PlayerPrefs.SetInt("highscore", scoreCounter); //vista nyja metið
        }else{
            highScoreText.text = "Metið: " + highScore.ToString();
        }
    }
}
