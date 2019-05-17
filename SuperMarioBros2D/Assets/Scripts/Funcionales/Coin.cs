using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject scoreboard;
    private bool picked;

    void Start()
    {
        picked = false;
        scoreboard = GameObject.Find("Canvas");
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("Mario") &&!picked)
        {
            picked = true;
            //Añadimos el score correspondiente y +1 moneda.
            scoreboard.GetComponent<Scoreboard>().Coins++;
            scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 200;
            //Eliminamos la moneda.
            Destroy(gameObject);
        }
    }
}
