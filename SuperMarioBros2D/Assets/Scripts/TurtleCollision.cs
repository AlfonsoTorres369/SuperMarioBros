using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurtleCollision : MonoBehaviour
{
    public Turtle turtle;
    public Mario mario;
    private float nextJump = 0f;
    private float jumpRate = 0.2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            if (turtle.dead)
            {
                if (Time.time > nextJump)
                {
                    turtle.deadcollision = true;

                    if (turtle.gameObject.transform.position.x < mario.gameObject.transform.position.x)
                    {
                        turtle.direction = 1;
                    }
                    else
                    {
                        turtle.direction = -1;
                    }
                }
            }

            else
            {
                mario.hit();
            }
        }

        else
        {
            if (collision.gameObject.tag != "Turtle")
            {
                if (!turtle.dead)
                {
                    turtle.direction = -turtle.direction;
                }

                else if (turtle.dead && turtle.deadcollision)
                {

                    if (collision.gameObject.tag == "Goomba")
                    {
                        Destroy(collision.gameObject);
                    }
                    else if (collision.gameObject.tag == "Mario")
                    {
                        mario.hit();
                    }
                    else
                    {

                        turtle.direction = -turtle.direction;
                    }
                }
            }
        }
    }

}
