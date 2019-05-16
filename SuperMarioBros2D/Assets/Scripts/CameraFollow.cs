using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {

    //offset from the viewport center to fix damping
    public GameObject player;
    private float smoothTime;
    public bool cameraFollowX;
    public Vector2 velocity;

	void Start () 
    {
		smoothTime = 0.1f;
        cameraFollowX = false;
        velocity = new Vector2(5,0);
	}

    void Update() 
    {
       if(cameraFollowX)
       {
           transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTime),0,-10);
       } 
    }
}
