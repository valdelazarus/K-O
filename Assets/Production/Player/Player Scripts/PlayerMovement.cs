﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    private CharacterAnimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;

    private float rotation_Y = -90f;
    private float rotation_Speed = 15f;

    void Awake() {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    
    void Update() {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    void FixedUpdate() {
        DetectMovement();
    }

    void DetectMovement() {

        myBody.velocity = new Vector3(
            CrossPlatformInputManager.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
            myBody.velocity.y,
            CrossPlatformInputManager.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed));

    } 

    void RotatePlayer() { 

        if(CrossPlatformInputManager.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0) {

            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);

        } else if(CrossPlatformInputManager.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0) {

            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);

        }

    } 

    void AnimatePlayerWalk() { 
    	if (player_Anim) {
        	if(CrossPlatformInputManager.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 ||
                	CrossPlatformInputManager.GetAxisRaw(Axis.VERTICAL_AXIS) != 0) {

            			player_Anim.Walk(true);
    
        	} else {
            		player_Anim.Walk(false);
       	 		}
	}

    } 

} 






































