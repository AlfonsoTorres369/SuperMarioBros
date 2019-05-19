using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Flor : MonoBehaviour
{
    public float yfinal;
    public bool changed = false;
    public bool movcompleto = false;
    private GameObject scoreboard;
    private bool picked;
    private GameObject mario;

    void Start()
    {
        picked = false;
        scoreboard = GameObject.Find("Canvas");
        mario = GameObject.FindWithTag("Mario");
    }
    
    void Update()
    {
        movimiento(); 
    }

    void movimiento() {
        if (transform.position.y < yfinal)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f,1);
        else{
            movcompleto = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (movcompleto)
        {
            if (collision.gameObject.tag == "Mario" &&!picked)
            {
                picked = true;
                mario.GetComponent<Mario>().PlayFlowerSound();
                scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 1000;
                Destroy(gameObject);

            }
        }
    }

    public void getpos(float y) {
        yfinal = y;
    }
}
