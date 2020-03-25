using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public AudioClip pickupSound;

    protected abstract void OnPickedUp(GameObject target);

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<AudioSource>())
            {
                other.GetComponent<AudioSource>().PlayOneShot(pickupSound);
            }
            else
            {
                other.GetComponentInChildren<AudioSource>().PlayOneShot(pickupSound);
            }
            
            OnPickedUp(other.gameObject);
            Destroy(gameObject);
        }
    }
}
