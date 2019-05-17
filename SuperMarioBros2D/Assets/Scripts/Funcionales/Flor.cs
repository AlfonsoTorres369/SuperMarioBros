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

    void Start()
    {
        scoreboard = GameObject.Find("Canvas");
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
            if (collision.gameObject.tag == "Mario")
            {
                scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 1000;
                Destroy(gameObject);

            }
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

    public void getpos(float y) {
        yfinal = y;
    }
}
