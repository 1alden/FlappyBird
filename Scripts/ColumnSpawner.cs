using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject column;

    private float TimeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    public float maxY;
    public float minY;
    float randY;

    public GameObject score;

    public static int gameScore;
    public float addSpawn;
    public bool hasReachedScore = false;
    public float spawnDistanceEnd;
    // Start is called before the first frame update
    void Start()
    { 

        //InstantiateColumn();
    }

    // Update is called once per frame
    void Update()
    {
        gameScore = score.GetComponent<Score>().GetScore();

        if ( GameManager.gameOver == false && GameManager.gameHasStarted == true)
        {
            
                if (TimeBtwSpawn <= 0)
                {
                    InstantiateColumn();
                    TimeBtwSpawn = startTimeBtwSpawn;

                }
                else
                {
                    TimeBtwSpawn -= Time.deltaTime;
                }    
        }
    }

    public void InstantiateColumn()
    {
       
        randY = Random.Range(minY, maxY);
        GameObject newColumn = Instantiate(column);
        newColumn.transform.position = new Vector2(
            transform.position.x,
            randY);
        if(gameScore == 29)
        {
            minY = 0.2f;
            maxY = 0.2f;
        }
        if(gameScore >= 30 && gameScore < 50)
        {
            startTimeBtwSpawn = 1f;

            if (minY > -0.2f && maxY < 0.6f)
            {
                
                if (Random.Range(0, 2) == 0)
                {
                    minY = minY + spawnDistanceEnd;
                    maxY = maxY + spawnDistanceEnd;
                }
                else
                {
                    minY = minY - spawnDistanceEnd;
                    maxY = maxY - spawnDistanceEnd;
                }
            }
            else if(minY < -0.2f)
            {
                minY = minY + spawnDistanceEnd;
            }
            else if(maxY > 0.6f)
            {
                maxY = maxY + spawnDistanceEnd;
            }
               
        }
        if (gameScore >= 50 && gameScore < 99)
        {
            startTimeBtwSpawn = 1.25f;
            minY = -0.3f;
            maxY = 0.5f;
        }
        if (gameScore == 99)
        {
            minY = 0.2f;
            maxY = 0.2f;
        }
        if (gameScore >= 100 && gameScore < 150)
        {
            startTimeBtwSpawn = 0.55f;
           
            if (minY > -0.2f && maxY < 0.6f)
            {

                if (Random.Range(0, 2) == 0)
                {
                    minY = minY + spawnDistanceEnd;
                    maxY = maxY + spawnDistanceEnd;
                }
                else
                {
                    minY = minY - spawnDistanceEnd;
                    maxY = maxY - spawnDistanceEnd;
                }
            }
            else if (minY < -0.2f)
            {
                minY = minY + spawnDistanceEnd;
            }
            else if (maxY > 0.6f)
            {
                maxY = maxY + spawnDistanceEnd;
            }

        }
        if (gameScore >= 150)
        {
            startTimeBtwSpawn = 1f;
            minY = -0.35f;
            maxY = 0.45f;
        }


    }
    
}
