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
        SpawnAllPositions();
    }

    
    void Update()
    {
        
    }

    void SpawnRandomPosition()
    {
        int rand = Random.Range(0, hazardPrefabs.Length);
        int randPos = Random.Range(0, spawnPositions.Length);

        GameObject hazard = Instantiate(hazardPrefabs[rand], spawnPositions[randPos].position, Quaternion.identity);
        Destroy(hazard, spawnRate);
    }
    void SpawnAllPositions()
    {
        int rand = Random.Range(0, hazardPrefabs.Length);
        foreach (Transform t in spawnPositions)
        {
            Instantiate(hazardPrefabs[rand], t.position, Quaternion.identity);
        }
    }
}
