using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Wumpa")
        {
            c.gameObject.GetComponent<Goomba>().dead();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //tortuga

    }
}
