using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text highText;

    private int score = 0;
    private int highScore = 0;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        scoreText.text = score.ToString() + "";
        highText.text = "HIGHSCORE: " + highScore.ToString();
    }

    //Adds score and store it in score
    public void AddScore()
    {
        score += 1;
        scoreText.text = "SCORE: " + score.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

    }
}
