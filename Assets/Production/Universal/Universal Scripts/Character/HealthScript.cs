using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public float maxHealth;
    float health;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    public bool characterDied;

    public bool is_Player;

    private HealthUI health_UI;

    void Awake() {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        health = maxHealth;
        if(is_Player) {
            health_UI = GetComponent<HealthUI>();
        }
    }

    public void ApplyDamage(float damage, bool knockDown) {



        health -= damage;

      
        if(is_Player) {
            if (health_UI)
                health_UI.DisplayHealth(health, maxHealth);
        }

        if (health <= 0f && !characterDied) {
            if (animationScript)
            {
                animationScript.Death();
            }
            else 
            {
                Destroy(gameObject, 1f);
            }

            characterDied = true;

            if (is_Player) {
                GameObject.FindWithTag(Tags.ENEMY_TAG)
                    .GetComponent<EnemyMovement>().enabled = false;
            }
            
            else
            {
                FindObjectOfType<GameManager>()?.AddScore(GetComponent<EnemyStats>().scoreValue);
            }
                
             
            return;
        }

        if(!is_Player) { 

            if(knockDown) { 

                if(Random.Range(0, 2) > 0) {
                    animationScript.KnockDown();
                }

            } else {

                if (Random.Range(0, 3) > 1) {
                    animationScript.Hit();
                }

            }

        } 



    } 

    public void AddHealth(float value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        if (is_Player)
        {
            health_UI.DisplayHealth(health, maxHealth);
        }
    }

} 




































