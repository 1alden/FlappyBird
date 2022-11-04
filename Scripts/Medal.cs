using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    
    public Sprite normalMedal;
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;

    public GameObject sparkle1;

    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        int gameScore = GameManager.gameScore;

            if (gameScore >= 10 && gameScore <= 19)
        {
            img.sprite = bronzeMedal;
            sparkle1.SetActive(true);

        }
        else if(gameScore >= 20 && gameScore <= 29)
        {
            img.sprite = silverMedal;
            sparkle1.SetActive(true);
        }
        else if (gameScore >= 30 && gameScore <= 39)
        {
            
            img.sprite = goldMedal;
            sparkle1.SetActive(true);
        }
        else if (gameScore >= 40)
        {
            
            img.sprite = normalMedal;
            sparkle1.SetActive(true);
        }
    }

    
}
