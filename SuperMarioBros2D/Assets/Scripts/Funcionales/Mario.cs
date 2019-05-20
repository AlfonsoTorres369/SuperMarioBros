using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mario : MonoBehaviour
{
    private Rigidbody2D r;
    private Animator a;
    SpriteRenderer s;
    private GameObject scoreboard;
    public GameObject fireball;
    public Transform firespawn;

    public float moveX;
    public float Speed = 12f;
    public float jumpPower = 10f;
    public bool facingRight;
    public bool grounded = true;

    public int health = 1;
    private bool dead = false;
    public bool direction;
    public float deadPos;
    public AudioClip Mushroom;
    public AudioClip Coin;
    public AudioClip Dead;
    public AudioClip Flag;
    public AudioClip Jump;
    public AudioClip KillEnemy;
    public AudioClip Star;
    private AudioSource sound;
    private float LastHit;
    private bool win;
    private bool scoreRec;
    private GameObject gameover;
    private GameObject goomba;
    private bool fellDown;
    private float timeDead;
    private bool ShootMode;
    private float startime;
    public bool paused = false;
    public AudioClip Crashh;

    void Start(){

        ShootMode = false;
        timeDead = 0f;
        scoreRec = false;
        LastHit = 0f;
        scoreboard = GameObject.Find("Canvas");
        r = gameObject.GetComponent<Rigidbody2D>();
        a = gameObject.GetComponent<Animator>();
        s = gameObject.GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
        win = false;
        gameover = GameObject.Find("Score&SceneController");
        fellDown = false;

    }
    public void setpaused(bool pause) {
        paused = pause;
    }
    
    void Update(){

        if(!win)
        {
            if(!dead)
            {
                marioMovement();
                if (!paused)
                {
                    jump();
                }
                Shoot();
            }
            if(dead)
            {
                deadFell(deadPos);
            }
        }
        if(win && transform.position.y<-1.7)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        }
        fell();

    }


    public int requestDirection() {
        Debug.Log(direction);
        if (direction == false)
        {
            return 1;
        }
        else {
            return -1;
        }
    }

    void marioMovement(){

        moveX = Input.GetAxis("Horizontal");
        if (moveX != 0) {
            if (moveX > 0f)
            {
                direction = true;
                
            }
            else {
                Debug.Log("Hola");
                direction = false;
                
            }
        }
        flip(moveX);
        r.velocity = new Vector2(moveX * Speed, r.velocity.y);

        a.SetBool("Grounded", grounded);
        a.SetFloat("Walk", Mathf.Abs(moveX));
    }

    void jump(){

        if (Input.GetKeyDown(KeyCode.Space)){
            if (grounded && (Time.timeScale>0f)) {

                sound.PlayOneShot(Jump, 1f);
                r.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            }
        }

    }

    void flip(float moveX) {
        if (moveX > 0f)
        {
            direction = false;
            s.flipX = false;
        }
        if (moveX < 0f)
        {
            direction = true;
            s.flipX = true;
        }
    }

    public void seta() {

        sound.PlayOneShot(Mushroom, 1f);
        if (health == 1)
        {
            //animacion mario grande
            a.SetBool("SuperMario", true);
            health++;
        }
        
    }
    public void crash() {
        sound.PlayOneShot(Crashh, 1f);
    }
    public void fell()
    {
        if(transform.position.y <= -5.2f && !fellDown)
        {
            fellDown = true;
            a.SetBool("Dead", true);
            if(!dead)
            {
                sound.PlayOneShot(Dead, 1f);
            }
            timeDead = Time.time;
            
        }
        if(fellDown && Time.time - timeDead >= 3f)
        {
            gameover.GetComponent<GameOver>().Reload();
        }
    }

    public void hit() {
        if(Time.time - LastHit >= 1f)
        {
                if(health == 1)
            {
                dead = true;
                deadPos = transform.position.x;
                a.SetBool("Dead", true);
                health--;
                sound.PlayOneShot(Dead, 1f);
                
            }
            if(health == 2)
            {
                health--;
                a.SetBool("SuperMario", false);
            }
            LastHit = Time.time;
        }

    }

    void deadFell(float posX)
    {
        r.isKinematic = true;
        transform.position = new Vector3(posX, transform.position.y - 0.1f, transform.position.y);
    }

    public void PlayCoinSound()
    {
        sound.PlayOneShot(Coin, 1f);
    }

    public void PlayFlowerSound()
    {
        sound.PlayOneShot(Mushroom, 1f);
    }
    void OnTriggerExit2D(Collider2D c)
    {

        if (c.gameObject.tag == "Platform" ||c.gameObject.tag == "Ground")
        {

            grounded = false;
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {

        if (c.gameObject.tag == "Platform" || c.gameObject.tag == "Ground" ||c.gameObject.tag == "Box")
        {
            grounded = true;
        }

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Flag" && !scoreRec)
        {
            win = true;
            sound.PlayOneShot(Flag, 1f);
            a.SetBool("Win", true);
            scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 400;
            scoreRec = true;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Wumpa")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f, ForceMode2D.Impulse);
            goomba = c.gameObject;
            sound.PlayOneShot(KillEnemy, 1f);
            scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 100;
            //animacion
            goomba.GetComponent<Goomba>().dead();
        }
    }

    public void ShootModeOn()
    {
            sound.PlayOneShot(Star, 1f);
            ShootMode = true;
            startime = Time.time;
    }

    private void Shoot()
    {
        if(Time.time - startime >= 5f)
        {
            ShootMode = false;
        }
        else if(ShootMode)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
               Instantiate(fireball, firespawn.position, Quaternion.identity); 
            }
            //Disparar. Instaciar una bola en mario que avance.
        }
    }
   
   }
