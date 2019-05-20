using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Int : MonoBehaviour
{

    public string tipo;
    public GameObject seta;
    public GameObject flor;
    public GameObject coin;
    public GameObject star;
    private bool spawned = false;
    private Animator animation;
    public AudioClip Appear;
    private AudioSource sound;
    public float posFinal;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        animation = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Mario" && (transform.position.y > c.transform.position.y))
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
                    sound.PlayOneShot(Appear, 1f);
                    seta = Instantiate(seta, new Vector3(transform.position.x, transform.position.y + 0.1f, 1f), Quaternion.identity);
                    seta.GetComponent<Seta>().getPosFinal(posFinal);
                    
                }
                if (tipo == "Flower") {
                    animation.SetBool("Hitted", true);
                    sound.PlayOneShot(Appear, 1f);
                    flor = Instantiate(flor, new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
                    flor.GetComponent<Flor>().getpos(transform.position.y + 0.565f);
                }

                if(tipo == "Star")
                {
                    animation.SetBool("Hitted", true);
                    sound.PlayOneShot(Appear, 1f);
                    star = Instantiate(star, new Vector3(transform.position.x, transform.position.y+0.1f, 1f), Quaternion.identity);
                    star.GetComponent<Star>().getpos(transform.position.y + 0.6f);
                }
            }    
        }
    }

}
