using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float lifeTime;


    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    
    void Update()
    {
        float actualSpeed = (speed + acceleration) * Time.deltaTime;
        transform.position += Vector3.forward * actualSpeed;
    }
}
