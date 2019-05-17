using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mario : MonoBehaviour
{
    private Rigidbody2D r;
    private Animator a;
    SpriteRenderer s;

    public float moveX;
    public float Speed = 12f;
    public float jumpPower = 10f;
    public bool facingRight;
    public bool grounded = true;

    public int health = 1;
    public bool direction;

    void Start(){

        r = gameObject.GetComponent<Rigidbody2D>();
        a = gameObject.GetComponent<Animator>();
        s = gameObject.GetComponent<SpriteRenderer>();

    }

    
    void Update(){

        marioMovement();
        jump();
        fireCast();

    }
    public GameObject fire;
    public Transform firespawn;

    void fireCast()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            Instantiate(fire, firespawn.position, Quaternion.identity);
        }
    }

    public int requestDirection() {
        Debug.Log(direction);
        if (direction == false)
        {
            return 1;
        }
        else {
            return -1;
        }
    }

    void marioMovement(){

        moveX = Input.GetAxis("Horizontal");
        if (moveX != 0) {
            if (moveX > 0f)
            {
                direction = true;
                
            }
            else {
                Debug.Log("Hola");
                direction = false;
                
            }
        }
        flip(moveX);
        r.velocity = new Vector2(moveX * Speed, r.velocity.y);

        a.SetBool("Grounded", grounded);
        a.SetFloat("Walk", Mathf.Abs(moveX));
    }

    void jump(){

        if (Input.GetKeyDown(KeyCode.Space)){
            if (grounded) {

                r.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            }
        }

    }

    void flip(float moveX) {
        if (moveX > 0f)
        {
            direction = false;
            s.flipX = false;
        }
        if (moveX < 0f)
        {
            direction = true;
            s.flipX = true;
        }
    }

    public void seta() {

        if (health < 2)
        {
            //animacion mario grande
            health++;
        }
        
    }

    public void hit() {
        health--;

    }

    void OnTriggerExit2D(Collider2D c)
    {

        if (c.gameObject.tag == "Platform" ||c.gameObject.tag == "Ground")
        {

            grounded = false;
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {

        if (c.gameObject.tag == "Platform" || c.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }
   
   }
