using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Seta : MonoBehaviour
{
    private Rigidbody2D r;
    public Mario mario;
    public int direction = -1;
    public float speed = 20f;
    //public ScoreBoard s;
    private bool changed = false;
    void Start()
    {

        r = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        r.velocity = new Vector2(direction * speed, r.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        direction = -direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
           mario.seta();
           changePoints(1000);
           Destroy(gameObject);

        }
    }

    public void changePoints(int points)
    {
        
        if (changed == false)
        {
            changed = true;
            Text score = GameObject.Find("ScoreBoard").GetComponent<Text>();
            int scoreboard = System.Convert.ToInt32(score.text);
            scoreboard += points;
            score.text = String.Format("{0,6:000000}", scoreboard);
        }

    }
}
