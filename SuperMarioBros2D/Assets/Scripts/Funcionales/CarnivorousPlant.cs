using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorousPlant : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rb;
    private int direction;
    private float initialPosition;
    public float finalPosition;
    void Start()
    {
        direction = 1;
        initialPosition = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.y >= initialPosition)
        {
            direction = -1;
        }
        if(transform.position.y <= finalPosition)
        {
            direction = 1;
        }
        rb.velocity = new Vector2(rb.velocity.x, velocity*direction); //Aplicamos movimiento a la planta sólo en el eje Y.
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("Mario"))
        {
            Destroy(c.gameObject);
        }
    }

}
