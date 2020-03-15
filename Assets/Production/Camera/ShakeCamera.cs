﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {

    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1f;
    private bool should_Shake;
    private float initialDuration;

    private Vector3 startPosition;

    void Start() {
        startPosition = transform.localPosition;
        initialDuration = duration;
    }

    void Update() {
        Shake();
    }

    void Shake() {

        startPosition = transform.localPosition;
        if(should_Shake) { 
        
            if(duration > 0f) {

                Vector3 newPos = startPosition + Random.insideUnitSphere * power;
                newPos.y = startPosition.y;
                transform.localPosition = newPos;
                duration -= Time.deltaTime * slowDownAmount;

            } else {

                should_Shake = false;
                duration = initialDuration;
                transform.localPosition = startPosition;
            }

        } 

    } 

    public bool ShouldShake { 
        get {
            return should_Shake;
        }
        set {
            should_Shake = value;
        }
    }


} 







































