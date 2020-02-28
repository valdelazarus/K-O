using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileAOE : PlayerProjectile
{
    public float aoeActiveDuration;
    public float radius;
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
            foreach(Collider enemy in hit)
            {
                Vector3 hitFX_Pos = enemy.transform.position;
                hitFX_Pos.y += 1.3f;

                if (enemy.transform.forward.x > 0)
                {

                    hitFX_Pos.x += 0.3f;

                }
                else if (enemy.transform.forward.x < 0)
                {

                    hitFX_Pos.x -= 0.3f;

                }

                Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);

                //randomize damage and calculate with critical chance
                baseDamage = damage;

                damage += Random.Range(minDamage, maxDamage);

                bool isCritical = Random.value < criticalChance;
                if (isCritical)
                    damage *= criticalMultiplier;

                damage = (int)damage;

                if (isCritical)
                {
                    enemy.GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    enemy.GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
                enemy.GetComponent<AttackedScrollingText>().OnAttack(damage);

                damage = baseDamage;
            }
            

            aoeDealt = true;
        }
    }

}
