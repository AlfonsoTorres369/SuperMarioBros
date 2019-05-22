using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Turtle : MonoBehaviour
{
    private Rigidbody2D r;
    private Animator a;
    private SpriteRenderer s;
    private GameObject scoreboard;
    public bool deadcollision = false;
    public int direction = -1;
    public float speed = 20f;
    private GameObject mario;
    public bool dead = false;
    private AudioSource sound;
    public AudioClip KillEnemy;
    public bool change1 = false;
    public bool change2 = false;
    private bool pulsado;
    void Start()
    {
        mario = GameObject.FindWithTag("Mario");
        scoreboard = GameObject.Find("Canvas");
        r = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        s = gameObject.GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
        change2 = false;
        pulsado = false;
    }
    void flip()
    {
        if (r.velocity.x > 0f)
        {
            
            s.flipX = true;
        }
        if (r.velocity.x < 0f)
        {
            s.flipX = false;
        }
    }

    void Update()
    {
        checkpulsado();
        flip();
        if (!dead)
        {
            
            r.velocity = new Vector2(direction * speed, r.velocity.y);
        }

        else
        {
            if (deadcollision)
            {

                r.velocity = new Vector2(direction * 5, r.velocity.y);
                if (!change2)
                {
                    
                    scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 100;
                    change2 = true;
                }
            }
            else {
                
                r.velocity = new Vector2(0f, r.velocity.y);
            }
        }

    }
    void checkpulsado() {

        if (Input.GetKeyDown("m") && !pulsado)
        {
            pulsado = true;
        }
        else if (Input.GetKeyDown("m") && pulsado)
        {
            pulsado = false;
        }

    }



    private float nextJump=0f;
    private float jumpRate=0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mario" && collision.gameObject.transform.position.y > transform.position.y+0.2f)
        {

            if (Time.time > nextJump) // control del rebote
            {
                if (dead)
                {
                    if (deadcollision == false)
                    {
                            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f, ForceMode2D.Impulse);
                            
                        
                        deadcollision = true;
                        if (!change2)
                        {
                            //changePoints(100)
                            if (!pulsado)
                            {
                                sound.PlayOneShot(KillEnemy, 1f);
                            }
                            scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 100;
                            change2 = true;
                        }
                    }

                    else
                    {
                        
                            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f, ForceMode2D.Impulse);

                        if (!pulsado)
                        {
                            sound.PlayOneShot(KillEnemy, 1f);
                        }
                        r.velocity = new Vector2(0f, 0f);
                        deadcollision = false;
                    }

                }

                if (!dead) // si no esta muerto lo mata
                {

                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f, ForceMode2D.Impulse);
                   



                    a.SetBool("Dead", true);
                    if (!pulsado)
                    {
                        sound.PlayOneShot(KillEnemy, 1f);
                    }
                    if (!change1)
                    {
                        scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 100;
                    }
                     
                    dead = true;
                    Debug.Log("colision");
                }
            }
            nextJump = jumpRate + Time.time;
        }
    }

    public void changePoints(int points)
    {

            Text score = GameObject.Find("ScoreBoard").GetComponent<Text>();
            int scoreboard = System.Convert.ToInt32(score.text);
            scoreboard += points;
            score.text = String.Format("{0,6:000000}", scoreboard);
     
    }

    public void deadFire()
    {
        mario.GetComponent<Mario>().sound.PlayOneShot(KillEnemy, 1f);
        Destroy(gameObject);
    }

}


