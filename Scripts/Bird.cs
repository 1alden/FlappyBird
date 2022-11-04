using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public ColumnSpawner spawner;
    public GameManager gameManager;
    public Score score;
    public float speed;

    int angle;
    int maxAngle = 20;
    int minAngle = -90;

    public Sprite YellowDead;
    public Sprite GreenDead;
    public Sprite RedDead;
    public Sprite BlueDead;
    public Sprite GirlDead;
    public Sprite BotDead;

    public Animator getReadyAnim;
    public Animator birdPerantAnim;
    public Animator hitEffect;
    public Animator cameraAnim;

    private Animator anim;
    Rigidbody2D rb;
    private SpriteRenderer sp;
    bool touchedGround = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("PlayerSelected") == 0)
        {
            anim.SetTrigger("yellow");
        }
        if (PlayerPrefs.GetInt("PlayerSelected") == 1)
        {
            anim.SetTrigger("green");
        }
        if (PlayerPrefs.GetInt("PlayerSelected") == 2)
        {
            anim.SetTrigger("red");
        }
        if (PlayerPrefs.GetInt("PlayerSelected") == 3)
        {
            anim.SetTrigger("blue");
        }
        if (PlayerPrefs.GetInt("PlayerSelected") == 4)
        {
            anim.SetTrigger("girl");
        }
        if (PlayerPrefs.GetInt("PlayerSelected") == 5)
        {
            anim.SetTrigger("bot");
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameManager.gameOver == false && GameManager.gameIsPaused == false || Input.GetMouseButtonDown(0) && GameManager.gameOver == false && GameManager.gameIsPaused == false)
        {
            if(GameManager.gameHasStarted == false)
            {
                birdPerantAnim.enabled = false;
                rb.gravityScale = 0.8f;
                Flap();
                getReadyAnim.SetTrigger("FadeOut");

            }
            else
            {
                Flap();
            }
            
        }

        BirdRotation();

    }

    void Flap()
    {
        AudioManager.audiomanager.Play("flap");
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 0.8f;
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 0.6f;
            if(rb.velocity.y < -1.3f)
            {
                if (angle >= minAngle)
                {
                    angle = angle - 3;
                }
            }
            
        }
        if(touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.gameOver == false)
        {
            if (collision.CompareTag("Column"))
            {
                AudioManager.audiomanager.Play("point");

                score.Scored();
            }
            else if (collision.CompareTag("Pipe"))
            {
                //BirdDieEffect();
                
                gameManager.GameOver();
                BirdDieEffect();
            }

        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                //BirdDieEffect();
                
                gameManager.GameOver();
                GameOver();
                BirdDieEffect();
            }
            else
            {
                touchedGround = true;
                GameOver();
            }

        }
    }
    void GameOver()
    {
        touchedGround = true;
        anim.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        if(PlayerPrefs.GetInt("PlayerSelected") == 0)
        {
            sp.sprite = YellowDead;
        }
        else if(PlayerPrefs.GetInt("PlayerSelected") == 1)
        {
            sp.sprite = GreenDead;
        }
        else if (PlayerPrefs.GetInt("PlayerSelected") == 2)
        {
            sp.sprite = RedDead;
        }
        else if (PlayerPrefs.GetInt("PlayerSelected") == 3)
        {
            sp.sprite = BlueDead;
        }
        else if (PlayerPrefs.GetInt("PlayerSelected") == 4)
        {
            sp.sprite = GirlDead;
        }
        else if (PlayerPrefs.GetInt("PlayerSelected") == 5)
        {
            sp.sprite = BotDead;
        }
    }
    public void OnGetReadyAnimFinished()
    {
        
        gameManager.GameHasStarted();
    }
    void BirdDieEffect()
    {
        AudioManager.audiomanager.Play("hit");
        hitEffect.SetTrigger("Hit");
        cameraAnim.SetTrigger("shake");
    }
}
