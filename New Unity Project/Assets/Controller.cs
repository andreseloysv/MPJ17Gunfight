﻿using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour {

    // Use this for initialization

    public float moveSpeed = 6;
    

    Rigidbody rigidbody;
    

    Camera viewCamera;
    
    Vector3 velocity;
    


    void Start () {

        rigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        

        velocity = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * moveSpeed;
       

    }

    void FixedUpdate() {

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        

    }
}