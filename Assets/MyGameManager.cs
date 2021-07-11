using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public int currentScore = 0;
    public int highScore;

    public Text currentScoreText;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        currentScoreText.text = "Score: " + currentScore;
        highScoreText.text = "Score: " + highScore;
    }

    public void addScore(int amount)
    {
        currentScore += amount;

        if (currentScore > highScore)
        {
            highScore = currentScore;

            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }
}
