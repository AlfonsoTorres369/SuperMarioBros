using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    private float yfinal;
    private bool movcompleto;
    private float yinicial;
    private GameObject scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        movcompleto = false;
        yfinal = transform.position.y +2f;
        yinicial = transform.position.y;
        scoreboard = GameObject.Find("Canvas");
        scoreboard.GetComponent<Scoreboard>().Coins++;
        scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 200;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(movcompleto)
        {
            if(transform.position.y > yinicial)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, 1f);
            }   
            else
            {
                
                Destroy(gameObject);
            }
        }
        else
        {
             if (transform.position.y < yfinal)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, 1f);
        else 
        {
            movcompleto = true;
        }
        }
    }
}
