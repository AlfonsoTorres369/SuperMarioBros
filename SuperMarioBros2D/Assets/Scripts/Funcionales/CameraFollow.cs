using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {

    //offset from the viewport center to fix damping
    public GameObject player;
    public bool allowMovement;
    

	void Start () 
    {
		allowMovement = false;
	}

    void Update() 
    {
        float direction = Input.GetAxis("Horizontal");
       if(allowMovement && direction>=0)
       {
           Vector3 move = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
           transform.position = move;
       }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("Mario"))
        {
            allowMovement = true;
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
        allowMovement = false;
    }
}
