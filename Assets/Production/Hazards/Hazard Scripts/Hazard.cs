using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damage;
    public bool affectAll;
    public float affectRate;

    bool canAffect = true;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!affectAll && other.tag == Tags.PLAYER_TAG)
        {
            other.GetComponent<HealthScript>().ApplyDamage(damage, false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (affectAll && canAffect)
        {
            canAffect = false;
            other.GetComponent<HealthScript>()?.ApplyDamage(damage, false);
            if (other.tag == Tags.ENEMY_TAG)
            {
                other.GetComponent<AttackedScrollingText>().OnAttack(damage, false);
            }
            StopCoroutine(ResetAffect());
            StartCoroutine(ResetAffect());
        }
    }

    IEnumerator ResetAffect()
    {
        yield return new WaitForSeconds(affectRate);
        canAffect = true;
    }
}
