using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBG : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite Day;
    public Sprite Night;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (Random.Range(0, 3) == 0)
        {
            sr.sprite = Night;
        }
        else
        {
            sr.sprite = Day;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
