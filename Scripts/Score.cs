using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    Text scoreText;

    //references
    public Text panelScore;
    public Text panelHighScore;

    public GameObject newImage;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        panelScore.text = score.ToString();
        scoreText.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        //panelScore.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
            newImage.SetActive(true);

        }

    }
}
