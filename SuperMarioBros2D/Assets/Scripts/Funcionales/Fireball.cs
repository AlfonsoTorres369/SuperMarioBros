﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private int direction;
    private GameObject mario;
    // Start is called before the first frame update
    void Start()
    {
       mario = GameObject.FindWithTag("Mario");
       if(mario.GetComponent<Mario>().direction)
       {
           direction = -1;
       }
       else
       {
           direction = 1;
       }
       Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Wumpa")
        {
            c.gameObject.GetComponent<Goomba>().dead();
            Destroy(gameObject);
        }
        else if(c.gameObject.tag == "Turtle")
        {
            c.gameObject.GetComponent<Turtle>().deadFire();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Shoot()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(500f*direction, 0f));
    }
}
