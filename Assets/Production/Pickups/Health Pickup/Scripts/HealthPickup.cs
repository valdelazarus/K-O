using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public float healthValue;

    protected override void OnPickedUp(GameObject target)
    {
        target.GetComponent<HealthScript>().AddHealth(healthValue);
    }

    
}
