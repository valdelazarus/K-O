using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float lifeTime;

    public float damage;
    public float minDamage;
    public float maxDamage;
    public float criticalMultiplier;
    public float criticalChance;

    public GameObject hit_FX_Prefab;

    public Vector3 direction;

    protected float baseDamage;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        float actualSpeed = (speed + acceleration) * Time.deltaTime;
        transform.position += direction * actualSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.ENEMY_TAG && !other.GetComponent<HealthScript>().characterDied)
        {
            Vector3 hitFX_Pos = other.transform.position;

            hitFX_Pos.y += 1.3f;

            if (other.transform.forward.x > 0)
            {

                hitFX_Pos.x += 0.3f;

            }
            else if (other.transform.forward.x < 0)
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

            if (isCritical)
            {
                other.GetComponent<HealthScript>().ApplyDamage(damage, true);
            }
            else
            {
                other.GetComponent<HealthScript>().ApplyDamage(damage, false);
            }
            other.GetComponent<AttackedScrollingText>().OnAttack(damage, isCritical);

            damage = baseDamage;

            Destroy(gameObject);
        }
    }
}
