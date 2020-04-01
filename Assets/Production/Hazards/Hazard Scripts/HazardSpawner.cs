﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public Transform[] spawnPositions; //for fixed
    public Transform[] randomSpawnPositions; //for random
    public GameObject[] hazardPrefabs;
    public float initialDelay;
    public float spawnRate; 

    void Start()
    {
        SpawnAllPositions();
        InvokeRepeating("SpawnRandomPosition", initialDelay, spawnRate);
    }

    
    void Update()
    {
        
    }

    void SpawnRandomPosition()
    {
        int randPos = Random.Range(0, randomSpawnPositions.Length);
        int rand = Random.Range(1, hazardPrefabs.Length);

        GameObject hazard = Instantiate(hazardPrefabs[rand], randomSpawnPositions[randPos].position, Quaternion.identity);
        Destroy(hazard, spawnRate);
    }
    void SpawnAllPositions()
    {
        foreach (Transform t in spawnPositions)
        {
            Instantiate(hazardPrefabs[0], t.position, Quaternion.identity);
        }
    }
}
