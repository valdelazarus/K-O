using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damage;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PLAYER_TAG)
        {
            other.GetComponent<HealthScript>().ApplyDamage(damage, false);
        }
    }
}
