using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    void OnBlackFadeFinished()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("MainGame");
        }
        else if(SceneManager.GetActiveScene().name == "MainGame")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
