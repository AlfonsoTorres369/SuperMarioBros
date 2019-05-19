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
    private bool changed = false;
    private GameObject scoreboard;
    private bool picked;
    public bool movcompleto;
    private float yfinal;

    void Start()
    {

        movcompleto = false;
        r = GetComponent<Rigidbody2D>();
        scoreboard = GameObject.Find("Canvas");
        picked = false;
        mario = GameObject.FindWithTag("Mario");
        r.isKinematic = true;

    }

    void Update()
    {
        if(movcompleto)
        {
            r.velocity = new Vector2(direction * speed, r.velocity.y);
        }
        else if(!movcompleto)
        {
            if(transform.position.y <= yfinal)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, 1f);
            }
            else
            {
                r.isKinematic = false;
                movcompleto = true;
            }
        }
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            
            direction = -direction;
        }

        if (collision.gameObject.tag == "Mario" &&!picked &&movcompleto)
        {
            picked = true;
            mario.GetComponent<Mario>().seta();
            scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 1000;
            Destroy(gameObject);

        }
    }

    public void getPosFinal(float y)
    {
        yfinal = y;
    }

   
}
