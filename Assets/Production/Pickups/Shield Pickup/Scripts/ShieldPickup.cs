using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : Pickup
{
    public float shieldDuration;

    protected override void OnPickedUp(GameObject target)
    {
        target.GetComponent<PlayerInventory>().AddShield(shieldDuration);
    }
}
