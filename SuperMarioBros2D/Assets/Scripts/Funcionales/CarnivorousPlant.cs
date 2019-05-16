using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorousPlant : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rb;
    private int direction;
    void Start()
    {
        direction = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, velocity*direction); //Aplicamos movimiento a la planta sólo en el eje Y.
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("Mario")) //Si Mario toca la planta, muere.
        {
            Destroy(c.gameObject, 0.2f);
        }
        if(c.gameObject.CompareTag("Top")) //Si la planta llega al límite de Top, cambiará su dirección y se desplazará hacia abajo
        {
            direction = -1;
        }
        if(c.gameObject.CompareTag("Bottom")) // Si la planta llega al límite de Bottom, cambiará su dirección y se desplazara hacia arriba.
        {
            direction = 1;
        }
    }
}
