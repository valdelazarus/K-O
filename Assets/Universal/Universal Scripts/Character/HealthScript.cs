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

        if (characterDied)
        {
            return;
        }

        health -= damage;

        // display health UI
        if(is_Player) {
            health_UI.DisplayHealth(health, maxHealth);
        }

        if (health <= 0f) {
            if (animationScript)
                animationScript.Death();
                
            characterDied = true;

            // if is player deactivate enemy script
            if(is_Player) {
                GameObject.FindWithTag(Tags.ENEMY_TAG)
                    .GetComponent<EnemyMovement>().enabled = false;
            }
            //if enemy, increment score
            else
            {
                FindObjectOfType<GameManager>()?.AddScore(GetComponent<EnemyStats>().scoreValue);
            }

            if(!animationScript)
                Destroy(gameObject, 1f);
             
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

        } // if is player



    } // apply damage



} // class




































