using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    protected abstract void OnPickedUp(GameObject target);

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnPickedUp(other.gameObject);
            Destroy(gameObject);
        }
    }
}
