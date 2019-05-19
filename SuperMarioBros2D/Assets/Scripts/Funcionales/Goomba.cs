using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{

    private Rigidbody2D r;
    private Animator a;


    public int direction = -1;
    public float speed = 2f;
    private bool isDead;
    public GameObject mario;

    void Start()
    {
        isDead = false;
        r = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        mario = GameObject.FindWithTag("Mario");

    }


    void Update()
    {

        if(!isDead)
        {
            r.velocity = new Vector2(direction * speed, r.velocity.y);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            mario.GetComponent<Mario>().hit();
        }


        else
        {
            direction = -direction;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MarioFoots")
        {
            dead();
        }
    }
    public void dead()
    {
        isDead = true;
        r.isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        a.SetBool("Dead", true);
        Destroy(gameObject, 0.35f);
    }

}
