using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject mario;
    void Start()
    {
        pulsado = false;
    }

    public bool pulsado;
    void Update()
    {
        if (Input.GetKeyDown("p")) {
            if (!pulsado) {
                mario.gameObject.GetComponent<Mario>().paused = true;
                pulsado = true;
                Time.timeScale = 0f;
            }
            else {
                Time.timeScale = 1f;
                pulsado = false;
                mario.gameObject.GetComponent<Mario>().paused = false;
            }
        }
    }
}
