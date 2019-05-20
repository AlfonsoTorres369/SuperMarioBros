using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateKoopa : MonoBehaviour
{
    public float x;
    public float y;
    private bool spawned = false;
    public GameObject koopa;

    public int direction;

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
                koopa = Instantiate(koopa, new Vector2(x, y), Quaternion.identity);
                koopa.GetComponent<Turtle>().direction = direction;
                spawned = true;
                gameObject.SetActive(false);

            }
        }

    }
}
