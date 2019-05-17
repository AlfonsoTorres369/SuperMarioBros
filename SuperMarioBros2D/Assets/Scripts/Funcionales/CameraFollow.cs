using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public bool allowMovement;
    

	void Start () 
    {
		allowMovement = false;
	}

    void Update() 
    {
        float direction = Input.GetAxis("Horizontal");
        //Función que mira si la x de mario es mayor que la x de la cámara. Cambiará el valor de allowMovement.
        allowMovement = CheckDistance();
        //Si la x de Mario es mayor o igual que la x de la cámara, la cámara se moverá con mario.
       if(allowMovement && direction>=0)
       {
           Vector3 move = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
           transform.position = move;
       }
    }

    bool CheckDistance()
    {
        bool resul = false;

        if(player.transform.position.x>=transform.position.x)
        {
            resul = true;
        }
        else if(player.transform.position.x<transform.position.x)
        {
            resul = false;
        }
        return resul;
    }
}
