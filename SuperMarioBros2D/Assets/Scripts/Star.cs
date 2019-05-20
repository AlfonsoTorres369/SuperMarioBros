using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private GameObject mario;
    private bool picked;
    private bool movcompleto;
    private GameObject  scoreboard;
    public float yfinal;
    // Start is called before the first frame update
    void Start()
    {
        movcompleto = false;
        scoreboard = GameObject.Find("Canvas");
        picked = false;
        mario = GameObject.FindWithTag("Mario");
    }

    // Update is called once per frame
    void Update()
    { 
        movimiento(); 
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Mario" && !picked && movcompleto)
        {
            picked = true;
            mario.GetComponent<Mario>().ShootModeOn();
            Destroy(gameObject);
        }

    }

    void movimiento() {
        if (transform.position.y < yfinal)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f,1);
        else{
            movcompleto = true;
        }
    }

    public void getpos(float y) 
    {
        yfinal = y;
    }
}
