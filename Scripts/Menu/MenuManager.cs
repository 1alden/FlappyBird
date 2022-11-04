using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator blackFadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameOver = false;
        GameManager.gameOver = false;
    }

    public void OnPlayBtnPressed()
    {
        AudioManager.audiomanager.Play("transition");
        blackFadeAnim.SetTrigger("FadeIn");
        Invoke("Menu", 0.25f);
        //SceneManager.LoadScene("MainGame");
        
    }

    void Menu()
    {
        SceneManager.LoadScene("MainGame");
    }

}
