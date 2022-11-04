using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;

    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gameIsPaused = false;
    public Animator blackFadeAnimator;

    public GameObject gameOverCanvas;
    public GameObject score;
    public GameObject PauseButton;


    public GameObject getReadyImg;

    public static int gameScore;

    int drawScore;

    public Text panelScore;
    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameHasStarted = false;
        gameIsPaused = false;

    }
    public void GameHasStarted()
    {
        score.SetActive(true);
        gameHasStarted = true;
        score.SetActive(true);

        getReadyImg.SetActive(false);
        PauseButton.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
       gameScore = score.GetComponent<Score>().GetScore();
        score.SetActive(false);
        gameOver = true;
        
        PauseButton.SetActive(false);
        
        Invoke("ActivateGameOverCanvas", 1);

    }
    public void OnOkBtnPressed()
    {
        blackFadeAnimator.SetTrigger("FadeIn");
        AudioManager.audiomanager.Play("transition");
        Invoke("RestartLevel", 0.25f);
    }
    public void OnMenuButtonPressed()
    {
        AudioManager.audiomanager.Play("transition");
        blackFadeAnimator.SetTrigger("FadeIn");
        Invoke("Menu", 0.25f);
        //SceneManager.LoadScene("Menu");
    }

    void ActivateGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
        AudioManager.audiomanager.Play("die");
    }
    public void DrawScore()
    {
        if (drawScore <= gameScore)
        {
            panelScore.text = drawScore.ToString();
            drawScore++;
            Invoke("DrawScore", 0.05f);
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    void Menu()
    {
        SceneManager.LoadScene("Menu");
        
    }
}
