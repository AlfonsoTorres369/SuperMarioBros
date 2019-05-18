using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float finalP;
    public float initP; 
    public string tipo;
    private bool vuelta = false;
    public float velocidad = 0.05f;
    void Start()
    {
        if (tipo == "Horizontal"){
            initP = transform.position.x - initP;
            finalP = transform.position.x + finalP;
        }

        if (tipo == "Vertical")
        {
            initP = transform.position.y - initP;
            finalP = transform.position.y + finalP;
        }

        if (tipo == null) {
            tipo = "Horizontal";
            initP = transform.position.x - initP;
            finalP = transform.position.x + finalP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tipo == "Horizontal") {
            if (!vuelta)
            {
                if (transform.position.x < finalP)
                {
                    gameObject.transform.position = new Vector2(transform.position.x + velocidad, transform.position.y);
                }
                else
                {
                    vuelta = !vuelta;
                }
            }
            else
            {
                if (transform.position.x > initP)
                {
                    gameObject.transform.position = new Vector2(transform.position.x - velocidad, transform.position.y);
                }
                else
                {
                    vuelta = !vuelta;
                }
            }
        }

        else {
            if (!vuelta)
            {
                if (transform.position.y < finalP)
                {
                    gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + velocidad);
                }
                else
                {
                    vuelta = !vuelta;
                }
            }
            else
            {
                if (transform.position.y > initP)
                {
                    gameObject.transform.position = new Vector2(transform.position.x , transform.position.y - velocidad);
                }
                else
                {
                    vuelta = !vuelta;
                }
            }
        }
    }
}
