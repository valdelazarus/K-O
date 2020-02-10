using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Move : MonoBehaviour
{
    public AnimationCurve curve;


    // Start is called before the first frame update
    void Start()
    {
      //  curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(5, 5));
        curve.preWrapMode = WrapMode.PingPong;
        curve.postWrapMode = WrapMode.PingPong;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += Vector3.forward * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, curve.Evaluate(Time.time));

    }

  
}
