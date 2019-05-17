using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Seta : MonoBehaviour
{
    private Rigidbody2D r;
    public GameObject mario;
    public int direction = -1;
    public float speed = 20f;
    //public ScoreBoard s;
    private bool changed = false;
    private GameObject scoreboard;
    private bool picked;
    void Start()
    {

        r = GetComponent<Rigidbody2D>();
        scoreboard = GameObject.Find("Canvas");
        picked = false;
        mario = GameObject.FindWithTag("Mario");

    }

    void Update()
    {
        r.velocity = new Vector2(direction * speed, r.velocity.y);
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            
            direction = -direction;
        }

        if (collision.gameObject.tag == "Mario" &&!picked)
        {
            picked = true;
           //mario.seta();
           scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 1000;
           Destroy(gameObject);

        }
    }

    void OnBecameInvisible()
    {
        /* if(transform.position.x < mario.transform.position.x)
        {
            Destroy(gameObject);
        }*/
        enabled = true;
        Destroy(gameObject);
    }
}
