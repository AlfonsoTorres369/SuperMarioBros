using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Int : MonoBehaviour
{

    public string tipo;
    public GameObject seta;
    public Flor flor;
    public Mario mario;
    private bool spawned = false;
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            if (!spawned)
            {
                spawned = true;

                if (tipo == "Moneda") { }
                if (tipo == "Seta")
                {
                    //animacion de bloque
                    Instantiate(seta, new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), Quaternion.identity);
                    
                }
                if (tipo == "Flor") {
                    Instantiate(flor, new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
                    flor.getpos(transform.position.y + 0.6f);
                }
            }    
        }
    }

}
