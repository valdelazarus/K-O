using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStatueHazard : MonoBehaviour
{
    public GameObject acidBall;
    public Transform spawnPoint;
    public float initialDelay;
    public float spawnRate; 

    void Start()
    {
        InvokeRepeating("SpawnAcidBall", initialDelay, spawnRate);
    }


    void Update()
    {

    }

    void SpawnAcidBall()
    {
        Instantiate(acidBall, spawnPoint.position, Quaternion.identity);
    }
}
