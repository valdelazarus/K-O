using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smooth;

    Transform target;

    Vector3 offset;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        offset = transform.position - target.position;
    }

    
    void LateUpdate()
    {
        if(target)
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, target.position.x + offset.x, smooth * Time.deltaTime),
                transform.position.y,
                transform.position.z);
    }
}
