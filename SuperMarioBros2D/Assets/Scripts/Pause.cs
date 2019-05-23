using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject mario;
    public AudioClip pause;
    private AudioSource sound;
    private GameObject camera;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        sound = GetComponent<AudioSource>();
        pulsado = false;
    }

    public bool pulsado;
    void Update()
    {
        if (Input.GetKeyDown("p")) {
            if (!pulsado) {
                camera.GetComponent<AudioSource>().mute = true;
                sound.PlayOneShot(pause, 1f);
                mario.gameObject.GetComponent<Mario>().paused = true;
                pulsado = true;
                Time.timeScale = 0f;
            }
            else {
                camera.GetComponent<AudioSource>().mute = false;
                Time.timeScale = 1f;
                pulsado = false;
                mario.gameObject.GetComponent<Mario>().paused = false;
            }
        }
    }
}
