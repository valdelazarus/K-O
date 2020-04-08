using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAOEDamage : MonoBehaviour
{
    public float aoeActiveDuration;
    public float radius;
    public float damage;
    public float minDamage;
    public float maxDamage;
    public float criticalMultiplier;
    public float criticalChance;

    float baseDamage;
    public GameObject hit_FX_Prefab;
    public LayerMask collisionLayer;
    float startTime;
    float currentActiveTime;

    bool aoeDealt;

    void Start()
    {
        startTime = Time.time;
    }

    void OnEnable()
    {
        startTime = Time.time;
        currentActiveTime = 0f;
        aoeDealt = false;
    }

    void Update()
    {
        if (Time.time - startTime >= 2f)
        {
            if (currentActiveTime <= aoeActiveDuration)
            {
                DetectDamage();
                currentActiveTime += Time.deltaTime;
            }
            else
            {
                DisableSpell();
                GetComponentInParent<EnemyMovement>().enabled = true;
            }
        }
    }


    void DisableSpell()
    {
        gameObject.SetActive(false);
    }

    void DetectDamage()
    {
        if (aoeDealt) return;

        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {
            foreach (Collider player in hit)
            {
                Vector3 hitFX_Pos = player.transform.position;
                hitFX_Pos.y += 1.3f;

                if (player.transform.forward.x > 0)
                {

                    hitFX_Pos.x += 0.3f;

                }
                else if (player.transform.forward.x < 0)
                {

                    hitFX_Pos.x -= 0.3f;

                }

                Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);


                baseDamage = damage;

                damage += Random.Range(minDamage, maxDamage);

                bool isCritical = Random.value < criticalChance;
                if (isCritical)
                    damage *= criticalMultiplier;

                damage = (int)damage;

                player.gameObject.GetComponent<HealthScript>().ApplyDamage(damage, false);

                damage = baseDamage;
            }


            aoeDealt = true;
        }
    }

}
