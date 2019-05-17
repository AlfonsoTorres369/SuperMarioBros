using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Int : MonoBehaviour
{

    public string tipo;
    public GameObject seta;
    public GameObject flor;
    public GameObject coin;
    private bool spawned = false;
    private Animator animation;

    void Start()
    {
        animation = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Mario")
        {
            if (!spawned)
            {
                spawned = true;

                if (tipo == "Coin") 
                {
                    animation.SetBool("Hitted", true);
                    Instantiate(coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

                }
                if (tipo == "Mushroom")
                {
                    animation.SetBool("Hitted", true);
                    //animacion de bloque
                    Instantiate(seta, new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), Quaternion.identity);
                    
                }
                if (tipo == "Flower") {
                    animation.SetBool("Hitted", true);
                    Instantiate(flor, new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
                    flor.GetComponent<Flor>().getpos(transform.position.y + 0.556f);
                }
            }    
        }
    }

}
