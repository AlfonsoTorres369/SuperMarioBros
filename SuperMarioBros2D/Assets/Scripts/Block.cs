using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string tipo;
    public GameObject seta;
    public GameObject flor;
    public GameObject coin;
    public GameObject star;
    private bool spawned = false;
    private Animator animation;
    public AudioClip Appear;
    public AudioClip Bump;
 
    //otrosonido
    private AudioSource sound;
    public float posFinal;

    void Start()
    {
        if (tipo == " ") {
            tipo = "Normal";
        }
    }

    // Update is called once per frame
    void Update()
    {
        sound = GetComponent<AudioSource>();
        animation = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Mario" && (transform.position.y > c.transform.position.y))
        {
            if (!spawned)
            {
                spawned = true;

                if (tipo == "Coin")
                {
                    animation.SetBool("Active", false);
                    Instantiate(coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

                }
                if (tipo == "Mushroom")
                {
                    animation.SetBool("Active", false);
                    sound.PlayOneShot(Appear, 1f);
                    Instantiate(seta, new Vector3(transform.position.x, transform.position.y + 0.1f, 1f), Quaternion.identity);
                    seta.GetComponent<Seta>().getPosFinal(posFinal);

                }
                if (tipo == "Flower")
                {
                    animation.SetBool("Active", false);
                    sound.PlayOneShot(Appear, 1f);
                    Instantiate(flor, new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
                    flor.GetComponent<Flor>().getpos(posFinal);
                }

                if (tipo == "Star")
                {
                    animation.SetBool("Active", false);
                    sound.PlayOneShot(Appear, 1f);
                    Instantiate(star, new Vector3(transform.position.x, transform.position.y + 0.1f, 1f), Quaternion.identity);
                    Debug.Log(transform.position.y + 0.581f);
                    star.GetComponent<Star>().getpos(posFinal);
                }

                if (tipo == "Normal")
                {
                    if (c.gameObject.GetComponent<Mario>().health > 1)
                    {
                        c.gameObject.GetComponent<Mario>().crash();
                       
                        Destroy(gameObject, 0.1f);
                    }
                    else {
                        sound.PlayOneShot(Bump, 1f);
                    }
                }
            }
        }
    }
}
