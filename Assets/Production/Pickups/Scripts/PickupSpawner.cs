using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    public float dropRate;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SpawnRandomPickup(Vector3 pos)
    {
        float rand = Random.value;
        if (rand <= dropRate)
        {
            pos.y = 1f;
            int random = Random.Range(0, pickups.Length);
            Instantiate(pickups[random], pos, Quaternion.identity);
        }
        
    }
}
