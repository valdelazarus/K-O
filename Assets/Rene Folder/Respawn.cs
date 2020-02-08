using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Sphere;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBall()
    {
   
    }
}
