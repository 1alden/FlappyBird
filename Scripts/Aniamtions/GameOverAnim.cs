using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnim : MonoBehaviour
{
    public GameObject medal;
    public GameManager gameManager;
    public Space play;

    void OnGameOverAnimEnds()
    {
        medal.SetActive(true);
        //draw the score
        gameManager.DrawScore();
        play.enabled = true;
    }
}
