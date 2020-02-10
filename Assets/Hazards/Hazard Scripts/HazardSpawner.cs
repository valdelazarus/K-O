using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject[] hazardPrefabs;
    public float initialDelay;
    public float spawnRate; 

    void Start()
    {
        InvokeRepeating("SpawnHazard", initialDelay, spawnRate);
    }

    
    void Update()
    {
        
    }

    void SpawnHazard()
    {
        int rand = Random.Range(0, hazardPrefabs.Length);
        int randPos = Random.Range(0, spawnPositions.Length);

        GameObject hazard = Instantiate(hazardPrefabs[rand], spawnPositions[randPos].position, Quaternion.identity);
        Destroy(hazard, spawnRate);
    }
}
