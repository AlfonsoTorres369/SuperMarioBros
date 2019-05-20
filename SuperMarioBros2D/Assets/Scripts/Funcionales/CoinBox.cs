using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    private float yfinal;
    private bool movcompleto;
    private float yinicial;
    private GameObject scoreboard;
    private AudioSource sound;
    private GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        sound = GetComponent<AudioSource>();
        movcompleto = false;
        yfinal = transform.position.y +2f;
        yinicial = transform.position.y;
        scoreboard = GameObject.Find("Canvas");
        if(cam.GetComponent<DisableSound>().muteSound == false)
        {
            sound.Play();
        }
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
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.12f, 1f);
            }   
            else
            {
                
                Destroy(gameObject);
            }
        }
        else
        {
             if (transform.position.y < yfinal)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.07f, 1f);
        else 
        {
            movcompleto = true;
        }
        }
    }
}
