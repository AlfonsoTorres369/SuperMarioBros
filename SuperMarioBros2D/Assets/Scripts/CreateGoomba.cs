using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGoomba : MonoBehaviour
{
    public float x;
    public float y;
    private bool spawned = false;
    public GameObject goomba;

    public void Start(){

        if (y == -999) {
            y = transform.position.y;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Mario")
        {
            if (!spawned)
            {
                Instantiate(goomba, new Vector2(x, y), Quaternion.identity);
                spawned = true;
                gameObject.SetActive(false);

            }
        }

    }

}
