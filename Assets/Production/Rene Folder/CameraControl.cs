using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
 public Camera rb1;
    public Camera rb2;
    public Camera rb3;

    // Start is called before the first frame update
    void Start()
    {
        rb1.enabled = true;
        rb2.enabled = false;
        rb3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            rb1.enabled = true;
            rb2.enabled = false;
            rb3.enabled = false;
        }  else if (Input.GetKeyDown("s"))
        {
            rb1.enabled = false;
            rb2.enabled = true;
            rb3.enabled = false;
        }
        else if (Input.GetKeyDown("d"))
        {
            rb1.enabled = false;
            rb2.enabled = false;
            rb3.enabled = true;
        }


    }
}
