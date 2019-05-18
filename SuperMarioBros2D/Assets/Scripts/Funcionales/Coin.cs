using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject scoreboard;
    private bool picked;
    private GameObject mario;

    void Start()
    {
        picked = false;
        scoreboard = GameObject.Find("Canvas");
        mario = GameObject.FindWithTag("Mario");
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("Mario") &&!picked)
        {
            picked = true;
            mario.GetComponent<Mario>().PlayCoinSound();
            //Añadimos el score correspondiente y +1 moneda.
            scoreboard.GetComponent<Scoreboard>().Coins++;
            scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 200;
            //Eliminamos la moneda.
            Destroy(gameObject);
        }
    }
}
