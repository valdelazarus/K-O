using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerSpellAttack : MonoBehaviour
{
    public GameObject attack1Projectile;
    public GameObject attack2AOE;

    public float attack1Rate;
    public float attack2Rate;

    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
 
    bool canAttack1 = true, canAttack2 = true;

    float currentAttack1Time, currentAttack2Time;

    Vector3 spawnPos;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (CrossPlatformInputManager.GetButtonDown(Button.FIRE_1) && canAttack1)
        {
            audioSource.PlayOneShot(attack1Sound);
            spawnPos = transform.position;
            spawnPos.y = 1f;
            GameObject projectile = Instantiate(attack1Projectile, spawnPos, Quaternion.identity);
            projectile.GetComponent<PlayerProjectile>().direction = transform.forward;
            canAttack1 = false;
            currentAttack1Time = Time.time;
        }

        if (CrossPlatformInputManager.GetButtonDown(Button.FIRE_2) && canAttack2 && !attack2AOE.activeInHierarchy)
        {
            audioSource.PlayOneShot(attack2Sound);
            attack2AOE.SetActive(true);
            canAttack2 = false;
            currentAttack2Time = Time.time;
        }

        if (Time.time - currentAttack1Time >= attack1Rate)
        {
            canAttack1 = true;
        }

        if (Time.time - currentAttack2Time >= attack2Rate)
        {
            canAttack2 = true;
            attack2AOE.SetActive(false);
        }

    }
}
