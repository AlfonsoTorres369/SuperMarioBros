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
    private bool deadcollision = false;
    public int direction = -1;
    public float speed = 20f;
    public Mario mario;
    private bool dead = false;

    public bool change1 = false;
    public bool change2 = false;

    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        s = gameObject.GetComponent<SpriteRenderer>();
    }
    void flip()
    {
        if (r.velocity.x > 0f)
        {
            s.flipX = false;
        }
        if (r.velocity.x < 0f)
        {
            s.flipX = true;
        }
    }

    void Update()
    {
        if (!dead)
        {
            flip();
            r.velocity = new Vector2(direction * speed, r.velocity.y);
        }

        else
        {
            if (deadcollision)
            {
                
                r.velocity = new Vector2(direction * 7, r.velocity.y);
                if (!change2)
                {
                    changePoints(100);
                    change2 = true;
                }
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            if (dead)
            {
                deadcollision = true;
                direction = (int)(collision.gameObject.transform.position.x / Math.Abs(collision.gameObject.transform.position.x));
            }

            else
            {
                mario.hit();
            }
        }

        else
        {
            if (!dead)
            {
                direction = -direction;
            }
            if (dead && deadcollision) {
                
                if (collision.gameObject.tag == "Goomba") {
                    Destroy(collision.gameObject);
                }
            
            }
            else
            {
                direction = -direction;
            }
        }


    }
    private float nextJump=0f;
    private float jumpRate=0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            

            if (dead)
            {
                if (deadcollision == false)
                {
                    if (Time.time > nextJump)
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f, ForceMode2D.Impulse);
                        nextJump = jumpRate + Time.time;
                    }
                    deadcollision = true;
                    if (!change2)
                    {
                        changePoints(100);
                        change2 = true;
                    }
                }
                else
                {
                    if (Time.time > nextJump)
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f, ForceMode2D.Impulse);
                        nextJump = jumpRate + Time.time;
                    }
                    r.velocity = new Vector2(0f, 0f);
                    deadcollision = false;
                }
            }

            if (!dead)
            {
                if (Time.time > nextJump)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f, ForceMode2D.Impulse);
                    nextJump = jumpRate + Time.time;
                }
                a.SetBool("Dead", true);
                if (!change1)
                {
                    changePoints(100);
                    change1 = true;
                }
                dead = true;
            }

        }
    }

    public void changePoints(int points)
    {

            Text score = GameObject.Find("ScoreBoard").GetComponent<Text>();
            int scoreboard = System.Convert.ToInt32(score.text);
            scoreboard += points;
            score.text = String.Format("{0,6:000000}", scoreboard);
     
    }

}


