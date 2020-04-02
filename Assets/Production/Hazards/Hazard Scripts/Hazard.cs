using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damage;
    public bool affectAll;
    public float affectRate;
    public float radius;
    public LayerMask collisionLayer;
    public GameObject hit_FX_Prefab;

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
            if (hit_FX_Prefab)
            {
                Vector3 hitFX_Pos = other.transform.position;
                hitFX_Pos.y += 1.3f;
                Instantiate(hit_FX_Prefab, hitFX_Pos, hit_FX_Prefab.transform.rotation);
            }
            
            other.GetComponent<HealthScript>().ApplyDamage(damage, false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (affectAll && canAffect)
        {
            canAffect = false;
            DetectDamage();
            StopCoroutine(ResetAffect());
            StartCoroutine(ResetAffect());
        }
    }

    IEnumerator ResetAffect()
    {
        yield return new WaitForSeconds(affectRate);
        canAffect = true;
    }

    void DetectDamage()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {
            foreach (Collider obj in hit)
            {
                Vector3 hitFX_Pos = obj.transform.position;
                hitFX_Pos.y += 1.3f;

                if (obj.transform.forward.x > 0)
                {

                    hitFX_Pos.x += 0.3f;

                }
                else if (obj.transform.forward.x < 0)
                {

                    hitFX_Pos.x -= 0.3f;

                }

                Instantiate(hit_FX_Prefab, hitFX_Pos, hit_FX_Prefab.transform.rotation);

                obj.GetComponent<HealthScript>().ApplyDamage(damage, true);

                obj.GetComponent<AttackedScrollingText>()?.OnAttack(damage, false);

            }
        }
    }
}
